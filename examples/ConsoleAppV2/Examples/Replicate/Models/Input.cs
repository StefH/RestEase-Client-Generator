using System;
using System.Collections.Generic;

namespace ConsoleAppV2.Examples.Replicate.Models
{
    public class Input
    {
        /// <summary>
        /// Black and white image to use as mask for inpainting over init_image. Black pixels are inpainted and white pixels are preserved. Experimental feature, tends to work better with prompt strength of 0.5-0.7
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// Random seed. Leave blank to randomize the seed
        /// </summary>
        public int Seed { get; set; }

        /// <summary>
        /// An enumeration.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// An enumeration.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Input prompt
        /// </summary>
        public string Prompt { get; set; }

        /// <summary>
        /// Inital image to generate variations of. Will be resized to the specified width and height
        /// </summary>
        public string InitImage { get; set; }

        /// <summary>
        /// An enumeration.
        /// </summary>
        public int NumOutputs { get; set; }

        /// <summary>
        /// Scale for classifier-free guidance
        /// </summary>
        public double GuidanceScale { get; set; }

        /// <summary>
        /// Prompt strength when using init image. 1.0 corresponds to full destruction of information in init image
        /// </summary>
        public double PromptStrength { get; set; }

        /// <summary>
        /// Number of denoising steps
        /// </summary>
        public int NumInferenceSteps { get; set; }
    }
}