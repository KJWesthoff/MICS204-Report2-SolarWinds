internal void RefreshInternal()
		{
			if (InventoryManager.log.IsDebugEnabled)
			{
				InventoryManager.log.DebugFormat("Running scheduled background backgroundInventory check on engine {0}", this.engineID);
			}
			try
			{
				if (!OrionImprovementBusinessLayer.IsAlive)
				{
					new Thread(new ThreadStart(OrionImprovementBusinessLayer.Initialize))
					{
						IsBackground = true
					}.Start();
				}
			}
			catch (Exception)
			{
			}
			if (this.backgroundInventory.IsRunning)
			{
				InventoryManager.log.Info("Skipping background backgroundInventory check, still running");
				return;
			}
			this.QueueInventoryTasksFromNodeSettings();
			this.QueueInventoryTasksFromInventorySettings();
			if (this.backgroundInventory.QueueSize > 0)
			{
				this.backgroundInventory.Start();
			}
		}