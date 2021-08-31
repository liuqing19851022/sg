#region C#文件说明

// /**********************************************************************************	
// 	* 类   名 ：IDGeneratorService.cs
// 	* 功能描述：<简单描述类的作用>
// 	* 机器名称：MJ-LIUJIANHUA
// 	* 命名空间：MJSaas.Services.IDGenerate.Implement
// 	* 文 件 名：IDGeneratorService.cs
// 	* 创建时间：2016-05-04 17:47
// 	* 作    者： MJKJ.用户名：>
// 
// 	* 修 改 人：<修改人名称>
// 	* 修改描述：<修改内容>
// 	* 修改时间：YYYY-MM-DD 00:00:00
// **********************************************************************************/

#endregion


namespace MJ.Service.Tool.Implement.IDGenerate
{
    using System;
    using System.Threading.Tasks;
    using MJ.Service.Tool.DTO.IDGenerate.Request;
    using MJ.Service.Tool.DTO.IDGenerate.Respond;
    using MJ.Service.Tool.Interface.IDGenerate;
    using MJUSS.Infrastructure.Core.BaseClass;
    using Orleans;

    public class IDGeneratorGrain : Grain, IIDGeneratorGrain
    {
        public IDGeneratorGrain()
        {
        }
        private void UpdateCurrentTimestamp()
        {
            var currentTime = DateTime.Now;
            _currentSecondCounter = (int)currentTime.Subtract(currentTime.Date).TotalSeconds;
        }
        private const int MaxSeed = 99999;//最大值
        private int _seed = 0;
        private int _currentSecondCounter = 0;
        public Task<long> GenerateID()
        {
            UpdateCurrentTimestamp();
            if (_seed >= MaxSeed)
            {
                UpdateCurrentTimestamp();
                _seed = 0;
            }
            _seed++;
            var genID = DateTime.Now.ToString("yyMMdd") + _currentSecondCounter.ToString("D5") + _seed.ToString("D5");
            return Task.FromResult(long.Parse(genID));
        }

        public override Task OnActivateAsync()
        {
            return base.OnActivateAsync();
        }
    }
}