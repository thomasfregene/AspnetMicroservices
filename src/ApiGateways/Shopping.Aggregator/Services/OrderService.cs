﻿using Shopping.Aggregator.Extensions;
using Shopping.Aggregator.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.Aggregator.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetOrdersByUserName(string userName)
        {
            var response = await _httpClient.GetAsync($"/api/v1/order/{userName}");
            return await response.ReadContentAs<List<OrderResponseModel>>();
        }
    }
}
