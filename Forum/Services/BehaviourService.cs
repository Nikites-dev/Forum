﻿using System;

namespace Forum.Services
{
    public class BehaviourService
    {
        public bool isShowCommentContent { get; set; }
        public bool isProfile { get; set; }
        public bool isShowSignComponent { get; set; }
        public String SelectInterest { get; set; }
        
        public void OnFilterChange(string newValue)
        {
            SelectInterest = newValue;
        }
    }
}