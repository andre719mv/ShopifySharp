﻿using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopifySharp.Filters;
using ShopifySharp.Infrastructure;

namespace ShopifySharp
{
    /// <summary>
    /// A service for manipulating Shopify's RecurringApplicationCharge API.
    /// </summary>
    public class RecurringChargeService : ShopifyService
    {
        /// <summary>
        /// Creates a new instance of <see cref="RecurringChargeService" />.
        /// </summary>
        /// <param name="myShopifyUrl">The shop's *.myshopify.com URL.</param>
        /// <param name="shopAccessToken">An API access token for the shop.</param>
        public RecurringChargeService(string myShopifyUrl, string shopAccessToken) : base(myShopifyUrl, shopAccessToken) { }

        /// <summary>
        /// Creates a <see cref="RecurringCharge"/>.
        /// </summary>
        /// <param name="charge">The <see cref="RecurringCharge"/> to create.</param>
        /// <returns>The new <see cref="RecurringCharge"/>.</returns>
        public virtual async Task<RecurringCharge> CreateAsync(RecurringCharge charge)
        {
            return await ExecutePostAsync<RecurringCharge>("recurring_application_charges.json", "recurring_application_charge", new { recurring_application_charge = charge });
        }

        /// <summary>
        /// Retrieves the <see cref="RecurringCharge"/> with the given id.
        /// </summary>
        /// <param name="id">The id of the charge to retrieve.</param>
        /// <param name="fields">A comma-separated list of fields to return.</param>
        /// <returns>The <see cref="RecurringCharge"/>.</returns>
        public virtual async Task<RecurringCharge> GetAsync(long id, string fields = null)
        {
            return await ExecuteGetAsync<RecurringCharge>($"recurring_application_charges/{id}.json", "recurring_application_charge", fields);
        }

        /// <summary>
        /// Retrieves a list of all past and present <see cref="RecurringCharge"/> objects.
        /// </summary>
        public virtual async Task<IEnumerable<RecurringCharge>> ListAsync(RecurringChargeListFilter filter = null)
        {
            return await ExecuteGetAsync<IEnumerable<RecurringCharge>>("recurring_application_charges.json", "recurring_application_charges", filter);
        }

        /// <summary>
        /// Activates a <see cref="RecurringCharge"/> that the shop owner has accepted.
        /// </summary>
        /// <param name="id">The id of the charge to activate.</param>
        public virtual async Task<RecurringCharge> ActivateAsync(long id)
        {
            return await ExecutePostAsync<RecurringCharge>($"recurring_application_charges/{id}/activate.json", "recurring_application_charge");
        }

        /// <summary>
        /// Deletes a <see cref="RecurringCharge"/>.
        /// </summary>
        /// <param name="id">The id of the charge to delete.</param>
        public virtual async Task DeleteAsync(long id)
        {
            await ExecuteDeleteAsync($"recurring_application_charges/{id}.json");
        }
    }
}
