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
                MessageBox.Show("��ѡ���ļ�");
                return;
            }

            if (File.Exists(sourceFile))
            {
                FileAttributes attributes = File.GetAttributes(sourceFile);

                // ����Ƿ����ֻ������
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    Console.WriteLine("�ļ���ֻ���ģ������Ƴ�ֻ������...");
                    // �Ƴ�ֻ������
                    attributes &= ~FileAttributes.ReadOnly;
                    File.SetAttributes(sourceFile, attributes);
                    Console.WriteLine("ֻ���������Ƴ���");
                }
                else
                {
                    Console.WriteLine("�ļ�����ֻ���ġ�");
                }
            }
            else
            {
                MessageBox.Show("�ļ������ڣ�");
                return;
            }

            using var fs = new FileStream(sourceFile, FileMode.Open, FileAccess.Read);
            using IWorkbook workbook = new HSSFWorkbook(fs);
            ISheet sheet1 = workbook.GetSheet("���豸�б�");

            if (sheet1 == null)
            {
                MessageBox.Show("�ļ���ʽ����,������sheet ���豸�б�");
                return;
            }

            var headRow = sheet1.GetRow(0);
            


            if (!"�豸ID".Equals(headRow.GetCell(0).StringCellValue))
            {
                MessageBox.Show("�ļ���ʽ����,��һ�в��� ���豸ID��");
                return;
            }

            if (!"IMEI".Equals(headRow.GetCell(1).StringCellValue))
            {
                MessageBox.Show("�ļ���ʽ����,�ڶ��в��� ��IMEI��");
                return;
            }

            if (!"�豸IMEI��".Equals(headRow.GetCell(2).StringCellValue))
            {
                MessageBox.Show("�ļ���ʽ����,�����в��� ���豸IMEI�š�");
                return;
            }

            if (!"ICCID".Equals(headRow.GetCell(3).StringCellValue))
            {
                MessageBox.Show("�ļ���ʽ����,�����в��� ��ICCID��");
                return;
            }

            var rowNbr = sheet1.LastRowNum;
            progressBar.Minimum = 0;
            progressBar.Maximum = rowNbr;
            progressBar.Visible = true;
            btnSave.Enabled = false;


            headRow.CreateCell(6).SetCellValue("��������");
            headRow.CreateCell(7).SetCellValue("ʧ��ԭ��");


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

                // ������ѯ
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

            MessageBox.Show("�ļ��޸���ɣ��ѱ��浽: " + outputPath);
        }

        private void txtFile_Click(object sender, EventArgs e) {
            var fd = new OpenFileDialog();
            fd.Filter = "Excel�ļ�|*.xls;";
            var result = fd.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtFile.Text = fd.FileName;
            }
        }
    }
}
