using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Barometer.Models
{
    public class QuestionList
    {
        private int id;
        private int projectId;
        private List<Question> questions;
        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public List<Question> Questions
        {
            get { return questions; }
            set { questions = value; }
        }
        
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }
        
    }
}