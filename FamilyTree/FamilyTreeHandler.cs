using System;
using System.Collections.Generic;
using System.Text;
using FamilyTree2.Constants;
using FamilyTree2.Models;
using geektrust.Constants;

namespace geektrust
{
    public class FamilyTreeHandler
    {
        private static readonly string FEMALE = "Female";

        private Member familyHead;

        public void addFamilyHead(string Name, string gender)
        {
            Gender g = (FEMALE.Equals(gender)) ? Gender.Female : Gender.Male;
            this.familyHead = new Member(Name, g, null, null);
        }

        public void AddSpouse(string memberName, string SpouseName, string gender)
        {
            var member = SearchMember(familyHead, memberName);
            if (member != null && member.Spouse == null)
            {
                Gender g = (FEMALE.Equals(gender)) ? Gender.Female : Gender.Male;
                Member sp = new Member(SpouseName, g, null, null);
                sp.AddSpouse(member);
                member.AddSpouse(sp);
            }
        }


        public string AddChild(string motherName, string childName, string gender)
        {
            string result;
            Member member = SearchMember(familyHead, motherName);
            if (member == null)
            {
                result = Message.PERSON_NOT_FOUND;
            }
            else if (childName == null || gender == null)
            {
                result = Message.CHILD_ADDITION_FAILED;
            }
            else if (member.Gender == Gender.Female)
            {
                var g = (FEMALE.Equals(gender)) ? Gender.Female : Gender.Male;
                var child = new Member(childName, g, member.Spouse, member);
                member.AddChild(child);
                result = Message.CHILD_ADDITION_SUCCEEDED;
            }
            else
            {
                result = Message.CHILD_ADDITION_FAILED;
            }
            return result;
        }

        public string GetRelationship(string person, string relationship)
        {

            string relations;
            var member = SearchMember(familyHead, person);
            if (member == null)
            {
                relations = Message.PERSON_NOT_FOUND;
            }
            else if (relationship == null)
            {
                relations = Message.PROVIDE_VALID_RELATION;
            }
            else
            {
                relations = GetRelationship(member, relationship);
            }

            return relations;

        }


        private string GetRelationship(Member member, string relationship)
        {
            string relations = "";
            switch (relationship)
            {
                case "Daughter": // couldn't use Relationship.DAUGHTER, as in case statement constant value is expected
                    relations = member.SearchChild(Gender.Female);
                    break;

                case "Son": // Relationship.SON
                    relations = member.SearchChild(Gender.Male);
                    break;

                case "Siblings":
                    relations = member.SearchSiblings();
                    break;

                case "Sister-In-Law":
                    relations = SearchInLaws(member, Gender.Female);
                    break;

                case "Brother-In-Law":
                    relations = SearchInLaws(member, Gender.Male);
                    break;

                case "Maternal-Aunt":
                    if (member.Mother != null)
                        relations = member.Mother.SearchAuntOrUncle(Gender.Female);
                    break;

                case "Paternal-Aunt":
                    if (member.Father != null)
                        relations = member.Father.SearchAuntOrUncle(Gender.Female);
                    break;

                case "Maternal-Uncle":
                    if (member.Mother != null)
                        relations = member.Mother.SearchAuntOrUncle(Gender.Male);
                    break;

                case "Paternal-Uncle":
                    if (member.Father != null)
                        relations = member.Father.SearchAuntOrUncle(Gender.Male);
                    break;

                default:
                    relations = Message.NOT_YET_IMPLEMENTED;
                    break;
            }

            return ("".Equals(relations)) ? Message.NONE : relations;

        }

        private string SearchInLaws(Member member, Gender gender)
        {
            string personName = member.Name;
            var sb = new StringBuilder("");
            string res = "";

            // search spouse mother children
            if (member.Spouse != null && member.Spouse.Mother != null)
            {
                res = member.Spouse.Mother.SearchChildren(gender, member.Spouse.Name);
            }
            sb.Append(res);

            // search mother children
            res = "";
            if (member.Mother != null)
            {
                res = member.Mother.SearchChildren(gender, personName);
            }
            sb.Append(res);

            return sb.ToString().Trim();
        }

        private Member SearchMember(Member head, string memberName)
        {
            if (memberName == null || head == null)
            {
                return null;
            }

            Member member = null;
            if (memberName.Equals(head.Name))
            {
                return head;
            }
            else if (head.Spouse != null && memberName.Equals(head.Spouse.Name))
            {
                return head.Spouse;
            }

            List<Member> childlist = new List<Member>();
            if (head.Gender == Gender.Female)
            {
                childlist = head.Children;
            }
            else if (head.Spouse != null)
            {
                childlist = head.Spouse.Children;
            }

            foreach (var child in childlist)
            {
                member = searchMember(child, memberName);
                if (member != null)
                {
                    break;
                }
            }
            return member;
        }

        private Member searchMember(Member head, String memberName)
        {
            if (memberName == null || head == null)
            {
                return null;
            }

            Member member = null;
            if (memberName.Equals(head.Name))
            {
                return head;
            }
            else if (head.Spouse != null && memberName.Equals(head.Spouse.Name))
            {
                return head.Spouse;
            }

            List<Member> childList = new List<Member>();
            if (head.Gender == Gender.Female)
            {
                childList = head.Children;
            }
            else if (head.Spouse != null)
            {
                childList = head.Spouse.Children;
            }

            foreach (Member child in childList)
            {
                member = searchMember(child, memberName);
                if (member != null)
                {
                    break;
                }
            }
            return member;
        }
    }
}
