using System;
using System.Collections.Generic;
using System.Text;

namespace FamilyTree2.Models
{
    public class Member
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Member Mother { get; set; }

        public Member Father { get; set; }
        public Member Spouse { get; set; }
        public List<Member> Children { get; set; }

        public Member(string name, Gender gender, Member father, Member mother)
        {
            this.Name = name;
            this.Gender = gender;
            this.Mother = mother;
            this.Father = father;
            this.Spouse = null;
            this.Children = new List<Member>();
        }

        public void AddChild(Member child)
        {
            this.Children.Add(child);
        }

        public void AddSpouse(Member spouse)
        {
            this.Spouse = spouse;
        }

        public string SearchChild(Gender gender)
        {
            var sb = new StringBuilder("");
            foreach (Member child in this.Children)
            {
                if (child.Gender == gender)
                {
                    sb.Append(child.Name).Append(" ");
                }
            }
            return sb.ToString().Trim();
        }

        public string SearchSiblings()
        {
            var sb = new StringBuilder("");
            if (this.Mother != null)
            {
                foreach (Member member in this.Mother.Children)
                {
                    if (!this.Name.Equals(member.Name))
                    {
                        sb.Append(member.Name).Append(" ");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        public string SearchChildren(Gender gender, string personName)
        {
            var sb = new StringBuilder("");

            foreach (Member member in this.Children)
            {
                if (!personName.Equals(member.Name) && member.Gender == gender)
                {
                    sb.Append(member.Name).Append(" ");
                }
            }

            return sb.ToString().Trim();
        }

        public string SearchAuntOrUncle(Gender gender)
        {

            StringBuilder sb = new StringBuilder("");

            if (this.Mother != null)
            {
                foreach (Member member in this.Mother.Children)
                {
                    if (!this.Name.Equals(member.Name) && member.Gender == gender)
                    {
                        sb.Append(member.Name).Append(" ");
                    }
                }
            }

            return sb.ToString().Trim();
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
