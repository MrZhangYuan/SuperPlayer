using System;

namespace SuperPlayer.Business
{
        public class FileExtension
        {
                public string Name { get; }
                public string Flag { get; }
                public FileType FileType { get; }
                internal FileExtension(string name, FileType type, string flag)
                {
                        if (string.IsNullOrEmpty(name))
                        {
                                throw new ArgumentNullException(nameof(name));
                        }
                        Name = name;
                        FileType = type;
                        Flag = flag;
                }

                public override bool Equals(object obj)
                {
                        FileExtension extension = obj as FileExtension;
                        return this.Name.Equals(extension?.Name);
                }
                public override int GetHashCode()
                {
                        return this.Name.GetHashCode();
                }
                public override string ToString()
                {
                        return this.Name;
                }
        }
}
