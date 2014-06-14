using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM.BE.DDL
{
    public class LogBE
    {
        public Guid FileId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid UserId { get; set; }
        public string ProfileName { get; set; }
        public string ProfileDescription { get; set; }
        public string FileName { get; set; }
        public string FileLink { get; set; }
        public string FileDescription { get; set; }
        public DateTime Date { get; set; }
        public int Inserts { get; set; }
        public int Updates { get; set; }
        public int Deletes { get; set; }
        public int Errors { get; set; }
        public string ErrorDescription { get; set; }
        public int Duration { get; set; }

        public LogBE()
        {
        }

        public LogBE(Guid fileId, DateTime date, string fileName, string fileLink, int inserts, int updates, int deletes, int errors, int duration)
        {
            this.FileId = fileId;
            this.Date = Date;
            this.FileName = fileName;
            this.FileLink = fileLink;
            this.Inserts = inserts;
            this.Updates = updates;
            this.Deletes = deletes;
            this.Errors = errors;
            this.Duration = duration;
        }

        public LogBE(Guid fileId, Guid profileId, Guid companyId, Guid userId,
            string profileName, string profileDescription, 
            string fileName, string fileLink, string fileDescription, DateTime date,
            int inserts, int updates, int deletes, int errors, string errorDescription, int duration)
        {
            this.FileId = fileId;
            this.ProfileId = profileId;
            this.CompanyId = companyId;
            this.UserId = userId;
            this.ProfileName = profileName;
            this.ProfileDescription = profileDescription;
            this.FileName = fileName;
            this.FileLink = fileLink;
            this.FileDescription = fileDescription;
            this.Date = Date;
            this.Inserts = inserts;
            this.Updates = updates;
            this.Deletes = deletes;
            this.Errors = errors;
            this.ErrorDescription = errorDescription;
            this.Duration = duration;
        }

    }
}
