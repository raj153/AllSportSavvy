using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
namespace AllSportApp.WP.Domain
{
    [Table(Name="Events")]
    public class Event
    {
        public Event()
        {
                this.eventDetails = new EntitySet<EventDetail>();
        }
        
        [Column(IsPrimaryKey=true, IsDbGenerated = true)]
        public int Id { get; set; }
        
        [Column]
        public string Name { get; set; }

        [Column]
        public string Location { get; set; }

        [Column]
        public DateTime Date { get; set; } 

        [Column]
        public string AddDetails { get; set; }

        private EntitySet<EventDetail> eventDetails;

        [Association(Name="FK_EventDetails_Events", Storage = "eventDetails", OtherKey = "eventId", ThisKey = "Id")]
        private ICollection<EventDetail> EventDetails
        {
            get { return eventDetails; }
            set { eventDetails.Assign(value);}
        }

        public ICollection<Team> Teams
        {
            get { return (from ed in EventDetails select ed.Team).ToList(); }
        } 
    }

    [Table(Name = "EventDetails")]
    public class EventDetail
    {
        [Column(IsPrimaryKey = true, Name = "Event")]
        private int eventId;

        private EntityRef<Event> events;

        [Association(Name = "FK_EventDetails_Events", IsForeignKey = true, Storage = "events", ThisKey = "eventId")]
        public Event Event
        {
            get { return events.Entity; }
            set { events.Entity=value; }
            
        }
        public EventDetail()
        {
            this.teams = new EntityRef<Team>();
            this.events = new EntityRef<Event>();
        }
        [Column(IsPrimaryKey = true, Name = "Team")]
        private int teamId;
        private EntityRef<Team> teams;
        [Association(Name ="FK_EventDetails_Teams", IsForeignKey = true, Storage = "teams", ThisKey = "teamId")]
        public Team Team
        {
            get { return teams.Entity; }
            set { teams.Entity = value; }
        } 
    }

    [Table(Name = "Teams")]
    public class Team
    {
        public Team()
        {
                this.eventDetails = new EntitySet<EventDetail>();
        }
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        private EntitySet<EventDetail> eventDetails;

        [Association(Name = "FK_EventDetails_Teams", Storage = "eventDetails", OtherKey = "teamId", ThisKey = "Id")]
        private ICollection<EventDetail> EventDetails
        {
            get { return eventDetails; }
            set { eventDetails.Assign(value); }
        }

        public ICollection<Event> Events
        {
            get { return (from ed in EventDetails select ed.Event).ToList(); }
        } 
    }



}
