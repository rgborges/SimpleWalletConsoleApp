using System;

namespace SimpleWalletConsoleApp.Models
{
    public partial class Tag
    {
        public Guid Id { protected set; get;}
        public string Name { set; get;}
        public TagColor Color { set; get;}
        public Tag(string name, TagColor color)
        {
            this.Name = name;
            this.Color = color;
            this.Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"Name: {Name}, Id: {Id},";
        }
    }
}