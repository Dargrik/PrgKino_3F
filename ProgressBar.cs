        private async void button4_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            await FillProgressBar(linear: true);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            await FillProgressBar(linear: false);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private async Task FillProgressBar(bool linear)
        {
            while (progressBar1.Value < progressBar1.Maximum)
            {
                if (linear)
                {
                    progressBar1.Value = Math.Min(progressBar1.Value + 1, progressBar1.Maximum);
                }
                else
                {
                    int increment = Math.Max(1, (progressBar1.Maximum - progressBar1.Value) / 10);
                    progressBar1.Value = Math.Min(progressBar1.Value + increment, progressBar1.Maximum);
                }

                await Task.Delay(50);
            }
        }
