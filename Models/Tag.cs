using System;

namespace SimpleWalletConsoleApp.Models
{
    public partial class Tag
    {
        public int Id { protected set; get;}
        public string Name { set; get;}
        public TagColor Color { set; get;}
        public Tag(string name, TagColor color)
        {
            this.Name = name;
            this.Color = color;
            this.Id = 0;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }
}