using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using FinalFinalcsc415ML.Model;

namespace FinalFinalcsc415
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private const string DATA_FILEPATH = @"C:\Users\Luke Albiero\source\repos\FinalFinalcsc415\FinalFinalcsc415\trainingSet.csv";

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ModelInput sampleData = CreateSingleDataSample(DATA_FILEPATH);
            var predictionResult = ConsumeModel.Predict(sampleData);

            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 17);
            this.label1.TabIndex = 7;
            if (predictionResult.Prediction == sampleData.Quote)
            {
                this.label1.Text = "MATCH: " + sampleData.Quote;
            }
            else 
            {
                this.label1.Text = "MISS: " + sampleData.Quote;
            }
            // 
            // pictureBox1
            // 
            if (predictionResult.Prediction == "Bargain")
                this.pictureBox1.Image = global::FinalFinalcsc415.Properties.Resources.bargain;

            if (predictionResult.Prediction == "Fish")
                this.pictureBox1.Image = global::FinalFinalcsc415.Properties.Resources.fish;

            if (predictionResult.Prediction == "Begins")
                this.pictureBox1.Image = global::FinalFinalcsc415.Properties.Resources.begins;

            if (predictionResult.Prediction == "Confusion")
                this.pictureBox1.Image = global::FinalFinalcsc415.Properties.Resources.confusion;

            this.pictureBox1.Location = new System.Drawing.Point(36, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(731, 341);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Prequel Predictor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private static ModelInput CreateSingleDataSample(string dataFilePath)
        {
            // Create MLContext
            MLContext mlContext = new MLContext();

            // Load dataset
            IDataView dataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: dataFilePath,
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

            // Use first line of dataset as model input
            // You can replace this with new test data (hardcoded or from end-user application)
            ModelInput sampleForPrediction = mlContext.Data.CreateEnumerable<ModelInput>(dataView, false)
                                                                        .First();
            return sampleForPrediction;
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

