﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort {
	public class Slope : IPlace {
		public long ID { get; private set; }
		public string Name { get; private set; }
		public int OnSlope = 0;

		public TimeSpan Sleep;

		public Slope() {

		}
	}
}
