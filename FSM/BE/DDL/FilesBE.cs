using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.BE.DDL
{
    public class FilesBE
    {
        public Guid FileId { get; set; }
        public Guid ProfileId { get; set; }
        public string FileName { get; set; }
        public string FileLink { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public FilesBE() { }

        public FilesBE(Guid fileId)
        {
            this.FileId = fileId;
        }

        public FilesBE( string fileName, string fileLink, string description)
        {
            this.FileName = fileName;
            this.FileLink = fileLink;
            this.Description = description;
        }

        public FilesBE(Guid profileId, string fileName, string description)
        {
            this.ProfileId = profileId;
            this.FileName = FileName;
            this.Description = description;
        }

        public FilesBE(Guid fileId, Guid profileId, string fileName, string fileLink, string description)
        {
            this.FileId = fileId;
            this.ProfileId = profileId;
            this.FileName = fileName;
            this.FileLink = fileLink;
            this.Description = description;
        }

        public FilesBE(Guid fileId, Guid profileId, string fileName, string fileLink, string description, DateTime date)
        {
            this.FileId = fileId;
            this.ProfileId = profileId;
            this.FileName = fileName;
            this.FileLink = fileLink;
            this.Description = description;
            this.Date = date;
        }
    }
}
