﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ivvy
{
    public partial interface IApi
    {
        /// <summary>
        /// Returns a specific venue.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ResultOrError<Venue.Venue>> GetVenueAsync(int id);

        /// <summary>
        /// Returns a collection of venue accommodation rooms.
        /// </summary>
        /// <param name="venueId">The venue identifier.</param>
        /// <param name="perPage">The per page.</param>
        /// <param name="start">The start.</param>
        /// <returns></returns>
        Task<ResultOrError<ResultList<Venue.Room>>> GetVenueRoomListAsync(int venueId, int perPage, int start);

        /// <summary>
        /// Returns a collection of venue accommodation rooms options.
        /// </summary>
        /// <param name="venueId">The venue identifier.</param>
        /// <param name="perPage">The per page.</param>
        /// <param name="start">The start.</param>
        /// <returns></returns>
        Task<ResultOrError<ResultList<Venue.RoomOption>>> GetVenueRoomOptionListAsync(int venueId, int perPage, int start);

        /// <summary>
        /// Returns a collection of venue rate plans.
        /// </summary>
        /// <param name="venueId">The venue identifier.</param>
        /// <param name="perPage">The per page.</param>
        /// <param name="start">The start.</param>
        /// <returns></returns>
        Task<ResultOrError<ResultList<Venue.RatePlan>>> GetVenueRatePlanListAsync(int venueId, int perPage, int start);

        /// <summary>
        /// Returns a specific venue booking.
        /// </summary>
        /// <param name="venueId">The venue identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ResultOrError<Venue.Booking>> GetVenueBookingAsync(int venueId, int id);

        /// <summary>
        /// Returns a collection of booking accommodation groups in an iVvy venue.
        /// </summary>
        /// <param name="venueId">The unique id of the venue to which the bookings belong</param>
        /// <param name="bookingId">The unique id of the booking to which the accommodation belongs</param>
        /// <returns></returns>
        Task<ResultOrError<ResultList<Venue.Bookings.Accommodation>>> GetVenueBookingAccommodationListAsync(
            int venueId, int bookingId
        );

        /// <summary>
        /// Returns a collection of booking room reservations in an iVvy venue.
        /// </summary>
        /// <param name="venueId">The unique id of the venue to which the bookings belongs</param>
        /// <param name="perPage">The number of booking room reservations to fetch</param>
        /// <param name="start">The starting result of the page. Note this is zero based (i.e. sending start=0 will start from the first result.)</param>
        /// <param name="bookingId">The unique id of the booking to which the room reservations belong</param>
        /// <returns></returns>
        Task<ResultOrError<ResultList<Venue.Bookings.RoomReservation>>> GetVenueBookingRoomReservationListAsync(
            int venueId, int PerPage, int start, int? bookingId, Dictionary<string, object> filterRequest
        );

        /// <summary>
        /// Returns a collection of venue bookings in an iVvy venue.
        /// </summary>
        /// <param name="venueId">The venue identifier.</param>
        /// <param name="perPage">The per page.</param>
        /// <param name="start">The start.</param>
        /// <param name="filterRequest">The filter request.</param>
        /// <returns></returns>
        Task<ResultOrError<ResultList<Venue.Booking>>> GetVenueBookingListAsync(
            int venueId, int perPage, int start, Dictionary<string, object> filterRequest);

        /// <summary>
        /// Returns a collection of venue bookings in an iVvy account.
        /// </summary>
        /// <param name="perPage">The per page.</param>
        /// <param name="start">The start.</param>
        /// <param name="filterRequest">The filter request.</param>
        /// <returns></returns>
        Task<ResultOrError<ResultList<Venue.Booking>>> GetVenueBookingListForAccountAsync(
            int perPage, int start, Dictionary<string, object> filterRequest);

        /// <summary>
        /// Add or updates the dynamic inventory counts of a specific venue room.
        /// <param name="venueId">The unique id of the venue to which the room belongs</param>
        /// <param name="roomId">The unique id of the room for which the inventory count will be set</param>
        /// <param name="startDate">The start date from which the room inventory count will be set (Date Format)</param>
        /// <param name="endDate">The end date from which the room inventory count will be set (Date Format)</param>
        /// <param name="roomCount">The inventory count of the room from startDate to endDate</param>
        /// </summary>
        Task<ResultOrError<ResultSuccess>> AddOrUpdateVenueRoomCounts(
            int venueId,
            int roomId,
            string startDate,
            string endDate,
            int roomCount);

        /// <summary>
        /// Add or update the dynamic rates of a specific venue room.
        /// <param name="venueId">The unique id of the venue to which the rate plan belongs</param>
        /// <param name="ratePlanId">The unique id of the rate plan to which the dynamic rate applies</param>
        /// <param name="roomId">The unique id of the room to which the rate applies</param>
        /// <param name="startDate">The start date from which the dynamic rate will be set (Date Format)</param>
        /// <param name="endDate">The end date from which the dynamic rate will be set (Date Format)</param>
        /// <param name="cost">The rate amount from startDate to endDate. The amount must either include or exclude tax depending on how the venue has been configured</param>
        /// </summary>
        Task<ResultOrError<ResultSuccess>> AddOrUpdateVenueRoomDynamicRates(
            int venueId,
            int ratePlanId,
            int roomId,
            string startDate,
            string endDate,
            double cost);
        
        /// <summary>
        /// Remove one or more dynamic rates from a specific venue room.
        /// <param name="venueId">The unique id of the venue to which the rate plan belongs</param>
        /// <param name="ratePlanId">The unique id of the rate plan to which the dynamic rate applies</param>
        /// <param name="roomId">The unique id of the room to which the rate applies</param>
        /// <param name="startDate">The start date from which the dynamic rate will be removed (Date Format)</param>
        /// <param name="endDate">The end date until which the dynamic rate will be removed (Date Format)</param>
        /// </summary>
        Task<ResultOrError<ResultSuccess>> RemoveVenueRoomDynamicRates(
            int venueId,
            int ratePlanId,
            int roomId,
            string startDate,
            string endDate);

        /// <summary>
        /// Add or update the booking rules of a specific rate plan and room.
        /// <param name="venueId">The unique id of the venue to which the rate plan belongs</param>
        /// <param name="ratePlanId">The unique id of the rate plan to which the booking rule applies</param>
        /// <param name="roomId">The unique id of the room to which the booking rule applies</param>
        /// <param name="startDate">The start date from which the booking rule will apply (Date Format)</param>
        /// <param name="endDate">The end date until which the booking rule will apply (Date Format)</param>
        /// <param name="closeOutStatus">The close out status of the booking rule from startDate to endDate</param>
        /// </summary>
        Task<ResultOrError<ResultSuccess>> AddOrUpdateVenueRatePlanRules(
            int venueId,
            int ratePlanId,
            int roomId,
            string startDate,
            string endDate,
            Venue.RatePlan.CloseOutStatusOptions closeOutStatus);
    }
}
