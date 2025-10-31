using System;
using Microsoft.AspNetCore.Mvc;
using WaterJugChallenge.Models.RequestsModels;
using System.Collections.Generic;
using WaterJugChallenge.Helpers;


namespace WaterJugChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaterJugController : ControllerBase
    {

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody] WaterJugRequest request)
        {



            if (!WaterJugHelper.CheckIfPossible(request.XBucketCapacity, request.YBucketCapacity, request.ZAmountWanted))
            {
                return StatusCode(500, new { solution = "No solution" });
            }

            // Get the steps starting with X as the first bucket and Y as the second one.
            List<Step> stepsX = WaterJugHelper.SolveRiddle(request.XBucketCapacity, request.YBucketCapacity, request.ZAmountWanted, "X", "Y", false);

            // Get the steps starting with Y as the first bucket and X as the second one.
            List<Step> stepsY = WaterJugHelper.SolveRiddle(request.YBucketCapacity, request.XBucketCapacity, request.ZAmountWanted, "Y", "X", true);

            var steps = stepsX.Count <= stepsY.Count ? stepsX : stepsY;
            return Ok(new { solution = steps });

        }

    }
}
