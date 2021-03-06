using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Bandtracker
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Get["/band/delete_all"] = _ => {
                Band.DeleteAll();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Get["/venue/delete_all"] = _ => {
                Venue.DeleteAll();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Get["/band/add"] = _ => {
                return View["band_form.cshtml"];
            };
            Post["/band/add"] = _ => {
                Band newBand = new Band(Request.Form["band-name"]);
                newBand.Save();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Get["/venue/add"] = _ => {
                return View["venue_form.cshtml"];
            };
            Post["/venue/add"] = _ => {
                Venue newVenue = new Venue(Request.Form["venue-name"]);
                newVenue.Save();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Get["/band/{id}"] = parameters => {
                Band theBand = Band.FindBand(parameters.id);
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("band", theBand);
                model.Add("bandvenues", theBand.GetVenues());
                model.Add("venues", Venue.GetAll());
                return View["band.cshtml", model];
            };
            Post["/band/add_venue/{id}"] = parameters => {
                Band theBand = Band.FindBand(parameters.id);
                Venue theVenue = Venue.FindVenue(Request.Form["venue-name"]);
                theVenue.AddBand(theBand.GetId());
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Patch["/band/update/{id}"] = parameters => {
                Band updateBand = Band.FindBand(parameters.id);
                updateBand.UpdateBand(Request.Form["band-name"]);
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Delete["/band/delete/{id}"] = parameters => {
                Band deleteBand = Band.FindBand(parameters.id);
                deleteBand.DeleteBand();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Get["/venue/{id}"] = parameters => {
                Venue theVenue = Venue.FindVenue(parameters.id);
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("venue", theVenue);
                model.Add("venuebands", theVenue.GetBands());
                model.Add("bands", Band.GetAll());
                return View["venue.cshtml", model];
            };
            Post["/venue/add_band/{id}"] = parameters => {
                Venue theVenue = Venue.FindVenue(parameters.id);
                Band theBand = Band.FindBand(Request.Form["band-name"]);
                theVenue.AddBand(theBand.GetId());
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Patch["/venue/update/{id}"] = parameters => {
                Venue theVenue = Venue.FindVenue(parameters.id);
                theVenue.UpdateVenue(Request.Form["venue-name"]);
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
            Delete["/venue/delete/{id}"] = parameters => {
                Venue theVenue = Venue.FindVenue(parameters.id);
                theVenue.DeleteVenue();
                Dictionary<string, object> model = new Dictionary<string, object>{};
                model.Add("bands", Band.GetAll());
                model.Add("venues", Venue.GetAll());
                return View["index.cshtml", model];
            };
        }
    }
}
