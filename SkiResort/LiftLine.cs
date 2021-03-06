﻿using System;
using System.Collections.Generic;
using System.Threading;

// This class manages all the lifts

namespace SkiResort {
	public class LiftLine : IPlace {
		public Point From { get; set; }
		public Point To { get; set; }
		public int Frequency { get; private set; }
		public int LiftTime { get; private set; }
		public int Capacity { get; private set; }
		public string Name { get; private set; }
		public int Que { get; private set; }
		public int Weight { get; private set; }

		Resort Resort;
		Thread thisThread;
		List<Lift> Lifts = new List<Lift>(); // My lifts in progress

		public LiftLine(string name, Resort resort, int frequency, int lifttime, int capacity, int weight) {
			this.Name = name;
			this.Resort = resort;
			this.Frequency = frequency;
			this.LiftTime = lifttime;
			this.Capacity = capacity;
			this.Weight = weight;

			thisThread = new Thread(Run);
			thisThread.Start();
		}

		public void Run() {
			while (Resort.IsOpen) {
				Lift newLift = new Lift(this);
				Lifts.Add(newLift);
				Thread.Sleep(new TimeSpan(0, Frequency, 0));
			}
		}

		public int TakeLoad() {
			int Load;
			if (Que < Capacity) {
				Load = Que;
			} else Load = Capacity;

			return Load;
		}
		
		public void TakePassenger(int Passenger) {
			Que += Passenger;
		}
	}
}
