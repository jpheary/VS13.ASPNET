using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VS15.Models {
    //
    public class InvontoGatewayDbInitializer:DropCreateDatabaseAlways<InvontoGateway> {
        //Members

        //Interface
        protected override void Seed(InvontoGateway context) {
            //
            Group g1 = new Group { Name = "family" };
            Group g2 = new Group { Name = "friend" };
            Group g3 = new Group { Name = "colleague" };
            Group g4 = new Group { Name = "associate" };
            context.Groups.Add(g1);
            context.Groups.Add(g2);
            context.Groups.Add(g3);
            context.Groups.Add(g4);

            context.Contacts.Add(
                new Contact {
                    FirstName = "James",
                    LastName = "Heary",
                    Email = "james.heary@hotmail.com",
                    Phone = "732-692-0628",
                    Birthdate = "1961-08-02",
                    Profile = "/images/1.png",
                    Groups = new List<Group>(){ g1, g2 },
                    Comments = "I am the Invonto candidate."
                }
            );
            base.Seed(context);
        }
    }
}