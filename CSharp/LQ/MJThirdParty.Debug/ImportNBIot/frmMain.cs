using MJ.ThirdParty.NBIotCard.Recharge.Client;
using MJ.ThirdParty.NBIotCard.Recharge.Client.VO.Request;
using MJSamrtDevice.NetWork.GrpcClient;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Diagnostics;

namespace ImportNBIot
{
    public partial class frmMain : Form
    {
        private readonly ISpeekerImportApiAppSvrClient grpcImportClient;
        const int vendor = 1 << 19 | 3;
        public frmMain(ISpeekerImportApiAppSvrClient grpcImportClient)
        {
            InitializeComponent();
            this.grpcImportClient = grpcImportClient;
        }

        private async void btnSave_Click(object o,EventArgs e) {

            string sourceFile = txtFile.Text;
            if (string.IsNullOrEmpty(sourceFile))
            {
                MessageBox.Show("请选择文件");
                return;
            }

            if (File.Exists(sourceFile))
            {
                FileAttributes attributes = File.GetAttributes(sourceFile);

                // 检查是否包含只读属性
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    Console.WriteLine("文件是只读的，正在移除只读属性...");
                    // 移除只读属性
                    attributes &= ~FileAttributes.ReadOnly;
                    File.SetAttributes(sourceFile, attributes);
                    Console.WriteLine("只读属性已移除。");
                }
                else
                {
                    Console.WriteLine("文件不是只读的。");
                }
            }
            else
            {
                MessageBox.Show("文件不存在！");
                return;
            }

            using var fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            using IWorkbook workbook = new HSSFWorkbook(fs);
            ISheet sheet1 = workbook.GetSheet("云设备列表");

            if (sheet1 == null)
            {
                MessageBox.Show("文件格式错误,不存在sheet 云设备列表");
                return;
            }

            var headRow = sheet1.GetRow(0);
            


            if (!"设备ID".Equals(headRow.GetCell(0).StringCellValue))
            {
                MessageBox.Show("文件格式错误,第一列不是 【设备ID】");
                return;
            }

            if (!"IMEI".Equals(headRow.GetCell(1).StringCellValue))
            {
                MessageBox.Show("文件格式错误,第二列不是 【IMEI】");
                return;
            }

            if (!"设备IMEI号".Equals(headRow.GetCell(2).StringCellValue))
            {
                MessageBox.Show("文件格式错误,第三列不是 【设备IMEI号】");
                return;
            }

            if (!"ICCID".Equals(headRow.GetCell(3).StringCellValue))
            {
                MessageBox.Show("文件格式错误,第四列不是 【ICCID】");
                return;
            }

            var rowNbr = sheet1.LastRowNum;
            progressBar.Minimum = 0;
            progressBar.Maximum = rowNbr;
            progressBar.Visible = true;
            btnSave.Enabled = false;


            headRow.CreateCell(6).SetCellValue("激活日期");
            headRow.CreateCell(7).SetCellValue("失败原因");


            var i = 1;
            var lstIccIDs = new List<string>(100);
            var devicesReq = new SmartDevice.Grpc.RequestBatchAddSpeakerDTO
            {
                Vendor = vendor,
            };

            while (i < rowNbr)
            {
                var j = 0;
                for (;  j < 100; j++) {

                    var idx = i + j;
                    var currentRow = sheet1.GetRow(idx);
                    if (currentRow == null)
                        break;
      

                    var sn = currentRow.GetCell(0).StringCellValue;
                    if (string.IsNullOrEmpty(sn))
                        break;

                    var iccid = currentRow.GetCell(3)?.StringCellValue??string.Empty;
                    lstIccIDs.Add(iccid);

                    devicesReq.Devices.Add(new SmartDevice.Grpc.BatchAddSpeakerItemDTO
                    {
                        IccID = iccid,
                        SN = sn
                    });
                }

                progressBar.Value = i;

                //this.Text = $"{i}/{rowNbr}";
                Debug.WriteLine(i.ToString());

                // 批量查询
                if (lstIccIDs.Count == 0)
                    break;
                else {

                    var result = await this.grpcImportClient.BatchAddSpeaker(devicesReq);

                    if (result.ErrorCode == 0)
                    {

                        foreach (var item in result.Data.Datas)
                        {


                            var index = lstIccIDs.IndexOf(item.IccID);
                            if (index > -1) {
                                var currentRow = sheet1.GetRow(i + index);
                                currentRow.CreateCell(5).SetCellValue(item.IccID);
                                currentRow.CreateCell(6).SetCellValue(item.ActiveTime);
                                currentRow.CreateCell(7).SetCellValue(item.FaildReason);
                            }
                        }

                    }
                    else {
                        MessageBox.Show(result.ErrorMessage);
                    }

                    lstIccIDs.Clear();
                    devicesReq = new SmartDevice.Grpc.RequestBatchAddSpeakerDTO()
                    {
                        Vendor = vendor,
                    };

                    await Task.Delay(1000);

                }

                i += j;

            }

            var outputPath = sourceFile.Replace(".xls","_fixed.xlsx");
            using (FileStream outFs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(outFs);
            }


            progressBar.Visible = false;
            btnSave.Enabled = true;

            MessageBox.Show("文件修改完成，已保存到: " + outputPath);
        }

        private void txtFile_Click(object sender, EventArgs e) {
            var fd = new OpenFileDialog();
            fd.Filter = "Excel文件|*.xls;";
            var result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFile.Text = fd.FileName;
            }
        }
    }
}
