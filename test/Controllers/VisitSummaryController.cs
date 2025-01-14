﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;

namespace test.Controllers
{
    public class VisitSummaryController : Controller
    {
        private CapstoneEntities db = new CapstoneEntities();

        // GET: VisitSummary
        public ActionResult Index()
        {
            VisitSummary myModel = new VisitSummary();
            int intVisitId = (int)Session["intVisitId"];
            int intPetId = (int)Session["intPetID"];

            //General Information
            var informationPacket = (from o in db.TOwners
                                    join p in db.TPets
                                    on o.intOwnerID equals p.intOwnerID
                                    join s in db.TStates
                                    on o.intStateID equals s.intStateID
                                    join v in db.TVisits
                                    on p.intPetID equals v.intPetID
                                    where p.intPetID == intPetId
                                    select new
                                    {
                                        ownerName = o.strFirstName + " " + o.strLastName,
                                        address = o.strAddress + ", " + o.strCity + ", " + s.strStateName + " " + o.strZip,
                                        phoneNumber = o.strPhoneNumber,
                                        petName = p.strPetName,
                                        petNumber = p.strPetNumber,
                                        clientNumber = o.intOwnerID,
                                        dateOfVisit = v.dtmDateOfVist
                                    }).FirstOrDefault();

            var doctor = (from e in db.TEmployees
                          join ve in db.TVisitEmployees
                          on e.intEmployeeID equals ve.intEmployeeID
                          join j in db.TJobTitles
                          on e.intJobTitleID equals j.intJobTitleID
                          where ve.intVisitID == intVisitId
                          where j.intJobTitleID == 4
                          select new {
                              doctorName = "Dr. " + e.strFirstName + " " + e.strLastName
                          }).FirstOrDefault();

            //Save to model
            myModel.strOwnerName = informationPacket.ownerName;
            myModel.strAddress = informationPacket.address;
            myModel.strPhoneNumber = informationPacket.phoneNumber;
            myModel.intOwnerNumber = informationPacket.clientNumber;
            myModel.strPetName = informationPacket.petName;
            myModel.strPetNumber = informationPacket.petNumber;
            myModel.dtmOfVisit = informationPacket.dateOfVisit;
            myModel.strDoctor = doctor.doctorName;
            myModel.intPetID = intPetId;
            myModel.PetVisitServices = db.TVisitServices.Where(x => x.intVisitID == intVisitId).ToList();
            myModel.PetVisitMedications = db.TVisitMedications.Where(x => x.intVisitID == intVisitId).ToList();

            ViewBag.Name = informationPacket.petName;
            ViewBag.Total = db.TVisitServices
                            .Where(x => x.intVisitID == intVisitId)
                            .Select(z => z.TService.dblPrice)
                            .DefaultIfEmpty()
                            .Sum();

            return View(myModel);
        }
    }
}