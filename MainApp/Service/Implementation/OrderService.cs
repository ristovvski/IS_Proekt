﻿using IS_Proekt.Domain;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace IS_Proekt.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAll().ToList();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return _orderRepository.Get(id.Id);
        }
    }
}
