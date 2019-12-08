using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace _2019.Day6
{
    internal class Satellite
    {
        internal Satellite Parent { get; set; }
        internal List<Satellite> Children { get; private set; }

        internal Satellite(Satellite parent)
        {
            this.Parent = parent;
            this.Children = new List<Satellite>();
            if (parent != null)
            {
                parent.Children.Add(this);
            }
        }

        internal void SetParent(Satellite parent)
        {
            Debug.Assert(this.Parent == null && parent != null);
            this.Parent = parent;
            parent.Children.Add(this);
        }

        internal Satellite CommonAncestor(Satellite other)
        {
            var myParents = new List<Satellite>();
            var thisOne = this;
            while (thisOne != null)
            {
                myParents.Add(thisOne);
                thisOne = thisOne.Parent;
            }
            var thatOne = other;
            while (thatOne != null)
            {
                foreach (var p in myParents)
                {
                    if (object.ReferenceEquals(thatOne,p))
                    {
                        return p;
                    }
                }
                thatOne = thatOne.Parent;
            }
            throw new Exception("no common ancestor");
        }

        internal int ChainCount()
        {
            if (this.Parent == null)
            {
                return 0;
            }
            else
            {
                return 1 + this.Parent.ChainCount();
            }
        }

        internal int ChainCount(Satellite root)
        {
            if (object.ReferenceEquals(root, this))
            {
                return 0;
            }
            else
            {
                return 1 + this.Parent.ChainCount(root);
            }
        }
    }
}
