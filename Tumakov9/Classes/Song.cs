using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov9
{
    internal class Song
    {
        string name;
        string author;
        readonly Song prev;
        public Song(string name, string author, Song prev)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }
        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            this.prev = null;
        }
        public static string Title(Song song)
        {
            return $"{song.name} {song.author}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Song)
            {
                if ($"{this.name} {this.author}" == Song.Title(obj as Song))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
