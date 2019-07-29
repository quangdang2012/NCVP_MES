using Com.Nidec.Mes.Framework;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ProductionControllerCbm.SearchDetailAllLineProcessCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ProductionControllerCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ProductionControllerDetailForm : FormCommonNCVP
    {
        public ProductionControllerDetailForm()
        {
            InitializeComponent();
           // reportdowntime_dgv.AutoGenerateColumns = false;
        }
        public string _process;
        public string _model;
        public string _line;
        public string _dates;
        public string datefrom;
        public string dateto;

        public ProductionControllerDetailForm(string process, string model, string line, string dates) : this()
        {
            _process = process;
            _model = model;
            _line = line;
            _dates = dates;
        }
        private void ProductionControllerForm_Load(object sender, EventArgs e)
        {
            try
            {
                model_txt.Text = _model;
                line_txt.Text = _line;
                process_txt.Text = _process;
                timefrom_dtp.Value = timefrom_dtp.Value.Date.AddDays(-7);

                if (_line != "All Line")
                {
                    if (_process != "All")
                    {
                        GridBind();
                        search_grb.Visible = false;
                    }
                    else if (_process == "All")
                    {
                        chart_ng.Visible = false;
                        //string now = DateTime.Now.ToShortDateString();
                        GridBindByEachLineAllprocess(_dates, _dates, _line);
                    }
                }
                else
                {
                    if (_process != "All")
                    {
                        GridBindByAllLine(_dates, _dates);
                        search_grb.Visible = true;
                    }
                    else if(_process == "All" && _line == "All Line")
                    {
                        chart_ng.Visible = false;
                        //string now = DateTime.Now.ToShortDateString();
                        GridBindByAllLineAllprocess(_dates, _dates);
                    }
                    
                }                    
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }
        public void CreateColumnDGV()
        {
            production_controller_detail_dgv.Columns.Add("colTime", "Time");
            production_controller_detail_dgv.Columns["colTime"].DataPropertyName = "TimeHour";
            production_controller_detail_dgv.Columns.Add("colModel", "Model");
            production_controller_detail_dgv.Columns["colModel"].DataPropertyName = "ProModel";
            production_controller_detail_dgv.Columns.Add("colLine", "Line");
            production_controller_detail_dgv.Columns["colLine"].DataPropertyName = "ProLine";
            
            if (_process == "Holder")
            {
                production_controller_detail_dgv.Columns.Add("colGapHolder", "Gap Holder");
                production_controller_detail_dgv.Columns["colGapHolder"].DataPropertyName = "HolGapHolder";
            }
            else if (_process == "App Check")
            {
                production_controller_detail_dgv.Columns.Add("colApp_stamping_ba", "Stamping Ba");
                production_controller_detail_dgv.Columns.Add("colApp_case_set", "Case Set");
                production_controller_detail_dgv.Columns.Add("colApp_tough_shaft", "Tough Shaft");
                production_controller_detail_dgv.Columns.Add("colApp_case_glue_sticky", "Case Glue Sticky");
                production_controller_detail_dgv.Columns.Add("colApp_up_low_shabby", "Up Low Shabby");
                production_controller_detail_dgv.Columns.Add("colApp_hole_shaft", "Hole Shaft");
                production_controller_detail_dgv.Columns.Add("colApp_no_beat_prone_case", "No Beat Prone Case");
                production_controller_detail_dgv.Columns.Add("colApp_hole_case", "Hole Case");
                production_controller_detail_dgv.Columns.Add("colApp_prone_case", "Prone Case");
                production_controller_detail_dgv.Columns.Add("colApp_lot_ng", "Lot Ng");
                production_controller_detail_dgv.Columns.Add("colApp_ter_deform", "Ter Deform");
                production_controller_detail_dgv.Columns.Add("colApp_hole_ter", "Hole Ter");
                production_controller_detail_dgv.Columns.Add("colApp_soder_hl", "Soder Hl");
                production_controller_detail_dgv.Columns.Add("colApp_metal_oven_low", "Metal Oven Low");
                production_controller_detail_dgv.Columns.Add("colApp_fundou_ng", "Fundou Ng");
                production_controller_detail_dgv.Columns.Add("colApp_ter_glue_sticky", "Ter Glue Sticky");
                production_controller_detail_dgv.Columns.Add("colApp_lead_glue_sticky", "Lead Glue Sticky");

                production_controller_detail_dgv.Columns["colApp_stamping_ba"].DataPropertyName = "App_stamping_ba";
                production_controller_detail_dgv.Columns["colApp_case_set"].DataPropertyName = "App_case_set";
                production_controller_detail_dgv.Columns["colApp_tough_shaft"].DataPropertyName = "App_tough_shaft";
                production_controller_detail_dgv.Columns["colApp_case_glue_sticky"].DataPropertyName = "App_case_glue_sticky";
                production_controller_detail_dgv.Columns["colApp_up_low_shabby"].DataPropertyName = "App_up_low_shabby";
                production_controller_detail_dgv.Columns["colApp_hole_shaft"].DataPropertyName = "App_hole_shaft";
                production_controller_detail_dgv.Columns["colApp_no_beat_prone_case"].DataPropertyName = "App_no_beat_prone_case";
                production_controller_detail_dgv.Columns["colApp_hole_case"].DataPropertyName = "App_hole_case";
                production_controller_detail_dgv.Columns["colApp_prone_case"].DataPropertyName = "App_prone_case";
                production_controller_detail_dgv.Columns["colApp_lot_ng"].DataPropertyName = "App_lot_ng";
                production_controller_detail_dgv.Columns["colApp_ter_deform"].DataPropertyName = "App_ter_deform";
                production_controller_detail_dgv.Columns["colApp_hole_ter"].DataPropertyName = "App_hole_ter";
                production_controller_detail_dgv.Columns["colApp_soder_hl"].DataPropertyName = "App_soder_hl";
                production_controller_detail_dgv.Columns["colApp_metal_oven_low"].DataPropertyName = "App_metal_oven_low";
                production_controller_detail_dgv.Columns["colApp_fundou_ng"].DataPropertyName = "App_fundou_ng";
                production_controller_detail_dgv.Columns["colApp_ter_glue_sticky"].DataPropertyName = "App_ter_glue_sticky";
                production_controller_detail_dgv.Columns["colApp_lead_glue_sticky"].DataPropertyName = "App_lead_glue_sticky";
            }
            else if (_process == "En2")
            {
                production_controller_detail_dgv.Columns.Add("colEn2_lock", "Lock");
                production_controller_detail_dgv.Columns.Add("colEn2_cut", "Cut");
                production_controller_detail_dgv.Columns.Add("colEn2_chattering", "Chattering");
                production_controller_detail_dgv.Columns.Add("colEn2_insulation", "Insulation");
                production_controller_detail_dgv.Columns.Add("colEn2_open", "Open");
                production_controller_detail_dgv.Columns.Add("colEn2_short", "Short");
                production_controller_detail_dgv.Columns.Add("colEn2_duty", "Duty");
                production_controller_detail_dgv.Columns.Add("colEn2_no", "No");
                production_controller_detail_dgv.Columns.Add("colEn2_var", "Var");
                production_controller_detail_dgv.Columns.Add("colEn2_reverse_spinning", "Reverse Spinning");
                production_controller_detail_dgv.Columns.Add("colEn2_starting_volt", "Starting Volt");
                production_controller_detail_dgv.Columns.Add("colEn2_io", "IO");

                production_controller_detail_dgv.Columns["colEn2_lock"].DataPropertyName = "En2_lock";
                production_controller_detail_dgv.Columns["colEn2_cut"].DataPropertyName = "En2_cut";
                production_controller_detail_dgv.Columns["colEn2_chattering"].DataPropertyName = "En2_chattering";
                production_controller_detail_dgv.Columns["colEn2_insulation"].DataPropertyName = "En2_insulation";
                production_controller_detail_dgv.Columns["colEn2_open"].DataPropertyName = "En2_open";
                production_controller_detail_dgv.Columns["colEn2_short"].DataPropertyName = "En2_short";
                production_controller_detail_dgv.Columns["colEn2_duty"].DataPropertyName = "En2_duty";
                production_controller_detail_dgv.Columns["colEn2_no"].DataPropertyName = "En2_no";
                production_controller_detail_dgv.Columns["colEn2_var"].DataPropertyName = "En2_var";
                production_controller_detail_dgv.Columns["colEn2_reverse_spinning"].DataPropertyName = "En2_reverse_spinning";
                production_controller_detail_dgv.Columns["colEn2_starting_volt"].DataPropertyName = "En2_starting_volt";
                production_controller_detail_dgv.Columns["colEn2_io"].DataPropertyName = "En2_io";
            }
            else if (_process == "Fundou")
            {
                production_controller_detail_dgv.Columns.Add("colFd_ng_beat_point", "Beat Point");
                production_controller_detail_dgv.Columns.Add("colFd_fundou_deform", "Deform");

                production_controller_detail_dgv.Columns["colFd_ng_beat_point"].DataPropertyName = "Fd_ng_beat_point";
                production_controller_detail_dgv.Columns["colFd_fundou_deform"].DataPropertyName = "Fd_fundou_deform";
            }
            else if (_process == "En1")
            {
                production_controller_detail_dgv.Columns.Add("colEn1_lock", "Lock");
                production_controller_detail_dgv.Columns.Add("colEn1_cut", "Cut");
                production_controller_detail_dgv.Columns.Add("colEn1_chattering", "Chattering");
                production_controller_detail_dgv.Columns.Add("colEn1_insulation", "Insulation");
                production_controller_detail_dgv.Columns.Add("colEn1_open", "Open");
                production_controller_detail_dgv.Columns.Add("colEn1_bad_wave", "Bad Wave");
                production_controller_detail_dgv.Columns.Add("colEn1_duty", "Duty");
                production_controller_detail_dgv.Columns.Add("colEn1_short", "Short");
                production_controller_detail_dgv.Columns.Add("colEn1_beat_case_ng", "Baet Case NG");
                production_controller_detail_dgv.Columns.Add("colEn1_beat_fundou_ng", "Fundou NG");

                production_controller_detail_dgv.Columns["colEn1_lock"].DataPropertyName = "En1_lock";
                production_controller_detail_dgv.Columns["colEn1_cut"].DataPropertyName = "En1_cut";
                production_controller_detail_dgv.Columns["colEn1_chattering"].DataPropertyName = "En1_chattering";
                production_controller_detail_dgv.Columns["colEn1_insulation"].DataPropertyName = "En1_insulation";
                production_controller_detail_dgv.Columns["colEn1_open"].DataPropertyName = "En1_open";
                production_controller_detail_dgv.Columns["colEn1_bad_wave"].DataPropertyName = "En1_bad_wave";
                production_controller_detail_dgv.Columns["colEn1_duty"].DataPropertyName = "En1_duty";
                production_controller_detail_dgv.Columns["colEn1_short"].DataPropertyName = "En1_short";
                production_controller_detail_dgv.Columns["colEn1_beat_case_ng"].DataPropertyName = "En1_beat_case_ng";
                production_controller_detail_dgv.Columns["colEn1_beat_fundou_ng"].DataPropertyName = "En1_beat_fundou_ng";
            }
            else if (_process == "Insert Case")
            {
                production_controller_detail_dgv.Columns.Add("colInsc_no_ink_case_mc1", "No Ink Case");
                production_controller_detail_dgv.Columns.Add("colInsc_ba_deform_mc1", "Ba Deform");
                production_controller_detail_dgv.Columns.Add("colInsc_break_case_mc1", "Break Case");
                production_controller_detail_dgv.Columns.Add("colInsc_drop_mc1", "Drop");
                production_controller_detail_dgv.Columns.Add("colInsc_break_wire_mc1", "Break Wire");
                production_controller_detail_dgv.Columns.Add("colInsc_break_ring_mc1", "Break Ring");

                production_controller_detail_dgv.Columns["colInsc_no_ink_case_mc1"].DataPropertyName = "Insc_no_ink_case_mc1";
                production_controller_detail_dgv.Columns["colInsc_ba_deform_mc1"].DataPropertyName = "Insc_ba_deform_mc1";
                production_controller_detail_dgv.Columns["colInsc_break_case_mc1"].DataPropertyName = "Insc_break_case_mc1";
                production_controller_detail_dgv.Columns["colInsc_drop_mc1"].DataPropertyName = "Insc_drop_mc1";
                production_controller_detail_dgv.Columns["colInsc_break_wire_mc1"].DataPropertyName = "Insc_break_wire_mc1";
                production_controller_detail_dgv.Columns["colInsc_break_ring_mc1"].DataPropertyName = "Insc_break_ring_mc1";
            }
            else if (_process == "RA")
            {
                production_controller_detail_dgv.Columns.Add("colRA_com_pb_sticky", "Com Pb Stciky");
                production_controller_detail_dgv.Columns.Add("colRA_wire_pb_sticky", "Wire Pb Sticky");
                production_controller_detail_dgv.Columns.Add("colRA_com_slip", "Com Slip");
                production_controller_detail_dgv.Columns.Add("colRA_renew_ring", "Renew Ring");
                production_controller_detail_dgv.Columns.Add("colRA_break_wire_final_app", "Break Wire Final App");
                production_controller_detail_dgv.Columns.Add("colRA_wire_combine_wrong", "Wire Combine Wrong");
                production_controller_detail_dgv.Columns.Add("colRA_core_ng", "Core NG");
                production_controller_detail_dgv.Columns.Add("colRA_segment_hole", "Segment Hole");
                production_controller_detail_dgv.Columns.Add("colRA_glue_sticky", "Glue Sticky");
                production_controller_detail_dgv.Columns.Add("colRA_loose_wire_final_app", "Loose Wire Final App");
                production_controller_detail_dgv.Columns.Add("colRA_lead_not_covered", "Lead Not Covered");
                production_controller_detail_dgv.Columns.Add("colRA_less_lead", "Less Lead");

                production_controller_detail_dgv.Columns["colRA_com_pb_sticky"].DataPropertyName = "RA_com_pb_sticky";
                production_controller_detail_dgv.Columns["colRA_wire_pb_sticky"].DataPropertyName = "RA_wire_pb_sticky";
                production_controller_detail_dgv.Columns["colRA_com_slip"].DataPropertyName = "RA_com_slip";
                production_controller_detail_dgv.Columns["colRA_renew_ring"].DataPropertyName = "RA_renew_ring";
                production_controller_detail_dgv.Columns["colRA_break_wire_final_app"].DataPropertyName = "RA_break_wire_final_app";
                production_controller_detail_dgv.Columns["colRA_wire_combine_wrong"].DataPropertyName = "RA_wire_combine_wrong";
                production_controller_detail_dgv.Columns["colRA_core_ng"].DataPropertyName = "RA_core_ng";
                production_controller_detail_dgv.Columns["colRA_segment_hole"].DataPropertyName = "RA_segment_hole";
                production_controller_detail_dgv.Columns["colRA_glue_sticky"].DataPropertyName = "RA_glue_sticky";
                production_controller_detail_dgv.Columns["colRA_loose_wire_final_app"].DataPropertyName = "RA_loose_wire_final_app";
                production_controller_detail_dgv.Columns["colRA_lead_not_covered"].DataPropertyName = "RA_lead_not_covered";
                production_controller_detail_dgv.Columns["colRA_less_lead"].DataPropertyName = "RA_less_lead";
            }
            else if (_process == "Solder Ring")
            {
                production_controller_detail_dgv.Columns.Add("colRigs_wire_pb_sticky", "Wire Pb Sticky");
                production_controller_detail_dgv.Columns.Add("colRigs_com_pb_sticky", "Com Pb Sticky");
                production_controller_detail_dgv.Columns.Add("colRigs_ring_prone", "Ring Prone");
                production_controller_detail_dgv.Columns.Add("colRigs_cracked_ring", "Cracked Ring");

                production_controller_detail_dgv.Columns["colRigs_wire_pb_sticky"].DataPropertyName = "Rigs_wire_pb_sticky";
                production_controller_detail_dgv.Columns["colRigs_com_pb_sticky"].DataPropertyName = "Rigs_com_pb_sticky";
                production_controller_detail_dgv.Columns["colRigs_ring_prone"].DataPropertyName = "Rigs_ring_prone";
                production_controller_detail_dgv.Columns["colRigs_cracked_ring"].DataPropertyName = "Rigs_cracked_ring";
            }
            else if (_process == "Solder Wire")
            {
                production_controller_detail_dgv.Columns.Add("colPbs_break_copper", "Break Copper");
                production_controller_detail_dgv.Columns.Add("colPbs_climb_core", "Climb Core");
                production_controller_detail_dgv.Columns.Add("colPbs_skip_edge", "Skip Edge");
                production_controller_detail_dgv.Columns.Add("colPbs_wire_combine_wrong", "Wire Combine Wrong");
                production_controller_detail_dgv.Columns.Add("colPbs_loose_wire", "Loose Wire");
                production_controller_detail_dgv.Columns.Add("colPbs_rizer_edge_ng", "Rizer Edge NG");
                production_controller_detail_dgv.Columns.Add("colPbs_core_ng", "Core NG");
                production_controller_detail_dgv.Columns.Add("colPbs_com_slip", "Com Slip");
                production_controller_detail_dgv.Columns.Add("colPbs_hole", "Hole");
                production_controller_detail_dgv.Columns.Add("colPbs_2_sleeve", "2 Sleeve");
                production_controller_detail_dgv.Columns.Add("colPbs_wire_pb_sticky", "Wire Pb Sticky");
                production_controller_detail_dgv.Columns.Add("colPbs_com_pb_sticky", "Com Pb Sticky");
                production_controller_detail_dgv.Columns.Add("colPbs_no_lead", "No Lead");

                production_controller_detail_dgv.Columns["colPbs_break_copper"].DataPropertyName = "Pbs_break_copper";
                production_controller_detail_dgv.Columns["colPbs_climb_core"].DataPropertyName = "Pbs_climb_core";
                production_controller_detail_dgv.Columns["colPbs_skip_edge"].DataPropertyName = "Pbs_skip_edge";
                production_controller_detail_dgv.Columns["colPbs_wire_combine_wrong"].DataPropertyName = "Pbs_wire_combine_wrong";
                production_controller_detail_dgv.Columns["colPbs_loose_wire"].DataPropertyName = "Pbs_loose_wire";
                production_controller_detail_dgv.Columns["colPbs_rizer_edge_ng"].DataPropertyName = "Pbs_rizer_edge_ng";
                production_controller_detail_dgv.Columns["colPbs_core_ng"].DataPropertyName = "Pbs_core_ng";
                production_controller_detail_dgv.Columns["colPbs_com_slip"].DataPropertyName = "Pbs_com_slip";
                production_controller_detail_dgv.Columns["colPbs_hole"].DataPropertyName = "Pbs_hole";
                production_controller_detail_dgv.Columns["colPbs_2_sleeve"].DataPropertyName = "Pbs_2_sleeve";
                production_controller_detail_dgv.Columns["colPbs_wire_pb_sticky"].DataPropertyName = "Pbs_wire_pb_sticky";
                production_controller_detail_dgv.Columns["colPbs_com_pb_sticky"].DataPropertyName = "Pbs_com_pb_sticky";
                production_controller_detail_dgv.Columns["colPbs_no_lead"].DataPropertyName = "Pbs_no_lead";
            }
            else if (_process == "Wingding")
            {
                production_controller_detail_dgv.Columns.Add("colWi_break_copper_mc", "Break Copper");
                production_controller_detail_dgv.Columns.Add("colWi_ruffle_copper_mc", "Rufle Copper");
                production_controller_detail_dgv.Columns.Add("colWi_edge_ng_mc", "Edge NG");
                production_controller_detail_dgv.Columns.Add("colWi_no_sleeve_mc", "No Sleeve");

                production_controller_detail_dgv.Columns["colWi_break_copper_mc"].DataPropertyName = "Wi_break_copper_mc";
                production_controller_detail_dgv.Columns["colWi_ruffle_copper_mc"].DataPropertyName = "Wi_ruffle_copper_mc";
                production_controller_detail_dgv.Columns["colWi_edge_ng_mc"].DataPropertyName = "Wi_edge_ng_mc";
                production_controller_detail_dgv.Columns["colWi_no_sleeve_mc"].DataPropertyName = "Wi_no_sleeve_mc";
            }
            else if (_process == "Welding")
            {
                production_controller_detail_dgv.Columns.Add("colWe_com_slip", "Com Slip");
                production_controller_detail_dgv.Columns.Add("colWe_long_shaft", "Long Shaft");
                production_controller_detail_dgv.Columns.Add("colWe_short_shaft", "Short Shart");

                production_controller_detail_dgv.Columns["colWe_com_slip"].DataPropertyName = "We_com_slip";
                production_controller_detail_dgv.Columns["colWe_long_shaft"].DataPropertyName = "We_long_shaft";
                production_controller_detail_dgv.Columns["colWe_short_shaft"].DataPropertyName = "We_short_shaft";
            }
            else if (_process == "Core")
            {
                production_controller_detail_dgv.Columns.Add("colCo_beat_core_ng", "Beat Core NG");
                production_controller_detail_dgv.Columns.Add("colCo_com_wrap", "Com Wrap");
                production_controller_detail_dgv.Columns.Add("colCo_core_ng", "Core");
                production_controller_detail_dgv.Columns.Add("colCo_com_glue_sticky", "Com Glue Sticky");

                production_controller_detail_dgv.Columns["colCo_beat_core_ng"].DataPropertyName = "Co_beat_core_ng";
                production_controller_detail_dgv.Columns["colCo_com_wrap"].DataPropertyName = "Co_com_wrap";
                production_controller_detail_dgv.Columns["colCo_core_ng"].DataPropertyName = "Co_core_ng";
                production_controller_detail_dgv.Columns["colCo_com_glue_sticky"].DataPropertyName = "Co_com_glue_sticky";
            }
        }
        private void GridBind()
        {
            production_controller_detail_dgv.DataSource = null;
            production_controller_detail_dgv.Columns.Clear();
            try
            {
                ProductionControllerVo vo = new ProductionControllerVo
                {
                    ProLine = _line,
                    ProModel = _model,
                    Date = _dates
                };
                CreateColumnDGV();
                if (_process == "Holder")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailHolderCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "App Check")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAppCheckCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "En2")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailEn2Cbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Fundou")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailFundouCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "En1")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailEn1Cbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Insert Case")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailInsertCaseCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "RA")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailRACbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Solder Ring")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailSolderRingCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Solder Wire")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailSolderWireCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Wingding")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailWingdingCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Welding")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailWeldingCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Core")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailCoreCbm(), vo);
                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                production_controller_detail_dgv.ClearSelection();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void GridBindByAllLine(string _datefrom,string _dateto)
        {
            production_controller_detail_dgv.DataSource = null;
            production_controller_detail_dgv.Columns.Clear();
            try
            {
                
                ProductionControllerVo vo = new ProductionControllerVo
                {
                    DateFrom = _datefrom,
                    DateTo = _dateto
                };
                CreateColumnDGV();
                if (_process == "Holder")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineHolderCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "App Check")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineAppCheckCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "En2")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineEn2Cbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Fundou")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineFundouCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "En1")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineEn1Cbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Insert Case")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineInsertCaseCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "RA")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineRACaseCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Solder Ring")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineSolderRingCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Solder Wire")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineSolderWireCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Wingding")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineWingDingCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Welding")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineWeldingCbm(), vo);

                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                else if (_process == "Core")
                {
                    ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineCoreCbm(), vo);
                    if (volist.GetList() != null && volist.GetList().Count > 0)
                    {
                        production_controller_detail_dgv.AutoGenerateColumns = false;
                        BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                        production_controller_detail_dgv.DataSource = bindingsource;
                    }
                    else
                    {
                        messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }
                production_controller_detail_dgv.ClearSelection();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private string directorySave = "";
        private void browser_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "d:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                linksave_txt.Text = fl.SelectedPath;
                directorySave = linksave_txt.Text;
            }
        }
        private void exportexcel_btn_Click(object sender, EventArgs e)
        {
            Common.ExcelClass_ProductionControl ex = new Common.ExcelClass_ProductionControl();
            string name = _model + "_" + _line + "_" + "_" + _process;
            ex.exportexcel(ref production_controller_detail_dgv, directorySave, name, _model, _line);
        }

        private void chart_ng_Click(object sender, EventArgs e)
        {
            int confirm_status_C = 4;//vao bieu do tron main
            ProductionControllerChart_CForm form = new ProductionControllerChart_CForm(ref  production_controller_detail_dgv ,model_txt.Text, line_txt.Text, process_txt.Text, confirm_status_C);
            form.ShowDialog(this);
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if (_process != "All")
            {
                datefrom = timefrom_dtp.Value.ToShortDateString();
                dateto = timeto_dtp.Value.ToShortDateString();
                GridBindByAllLine(datefrom, dateto);
            }
            else
            {
                if(_line == "All Line")
                GridBindByAllLineAllprocess(timefrom_dtp.Value.ToShortDateString(), timeto_dtp.Value.ToShortDateString());
                else
                    GridBindByEachLineAllprocess(timefrom_dtp.Value.ToShortDateString(), timeto_dtp.Value.ToShortDateString(),_line);
            }
        }
        public void CreateAllColumnDGV()
        {
            production_controller_detail_dgv.Columns.Add("colTime", "Time");
            production_controller_detail_dgv.Columns["colTime"].DataPropertyName = "TimeHour";
            production_controller_detail_dgv.Columns.Add("colModel", "Model");
            production_controller_detail_dgv.Columns["colModel"].DataPropertyName = "ProModel";
            production_controller_detail_dgv.Columns.Add("colLine", "Line");
            production_controller_detail_dgv.Columns["colLine"].DataPropertyName = "ProLine";

            production_controller_detail_dgv.Columns.Add("colGapHolder", "Gap Holder");
            production_controller_detail_dgv.Columns["colGapHolder"].DataPropertyName = "HolGapHolder";

            production_controller_detail_dgv.Columns.Add("colApp_stamping_ba", "Stamping Ba");
            production_controller_detail_dgv.Columns.Add("colApp_case_set", "Case Set");
            production_controller_detail_dgv.Columns.Add("colApp_tough_shaft", "Tough Shaft");
            production_controller_detail_dgv.Columns.Add("colApp_case_glue_sticky", "Case Glue Sticky");
            production_controller_detail_dgv.Columns.Add("colApp_up_low_shabby", "Up Low Shabby");
            production_controller_detail_dgv.Columns.Add("colApp_hole_shaft", "Hole Shaft");
            production_controller_detail_dgv.Columns.Add("colApp_no_beat_prone_case", "No Beat Prone Case");
            production_controller_detail_dgv.Columns.Add("colApp_hole_case", "Hole Case");
            production_controller_detail_dgv.Columns.Add("colApp_prone_case", "Prone Case");
            production_controller_detail_dgv.Columns.Add("colApp_lot_ng", "Lot Ng");
            production_controller_detail_dgv.Columns.Add("colApp_ter_deform", "Ter Deform");
            production_controller_detail_dgv.Columns.Add("colApp_hole_ter", "Hole Ter");
            production_controller_detail_dgv.Columns.Add("colApp_soder_hl", "Soder Hl");
            production_controller_detail_dgv.Columns.Add("colApp_metal_oven_low", "Metal Oven Low");
            production_controller_detail_dgv.Columns.Add("colApp_fundou_ng", "Fundou Ng");
            production_controller_detail_dgv.Columns.Add("colApp_ter_glue_sticky", "Ter Glue Sticky");
            production_controller_detail_dgv.Columns.Add("colApp_lead_glue_sticky", "Lead Glue Sticky");

            production_controller_detail_dgv.Columns["colApp_stamping_ba"].DataPropertyName = "App_stamping_ba";
            production_controller_detail_dgv.Columns["colApp_case_set"].DataPropertyName = "App_case_set";
            production_controller_detail_dgv.Columns["colApp_tough_shaft"].DataPropertyName = "App_tough_shaft";
            production_controller_detail_dgv.Columns["colApp_case_glue_sticky"].DataPropertyName = "App_case_glue_sticky";
            production_controller_detail_dgv.Columns["colApp_up_low_shabby"].DataPropertyName = "App_up_low_shabby";
            production_controller_detail_dgv.Columns["colApp_hole_shaft"].DataPropertyName = "App_hole_shaft";
            production_controller_detail_dgv.Columns["colApp_no_beat_prone_case"].DataPropertyName = "App_no_beat_prone_case";
            production_controller_detail_dgv.Columns["colApp_hole_case"].DataPropertyName = "App_hole_case";
            production_controller_detail_dgv.Columns["colApp_prone_case"].DataPropertyName = "App_prone_case";
            production_controller_detail_dgv.Columns["colApp_lot_ng"].DataPropertyName = "App_lot_ng";
            production_controller_detail_dgv.Columns["colApp_ter_deform"].DataPropertyName = "App_ter_deform";
            production_controller_detail_dgv.Columns["colApp_hole_ter"].DataPropertyName = "App_hole_ter";
            production_controller_detail_dgv.Columns["colApp_soder_hl"].DataPropertyName = "App_soder_hl";
            production_controller_detail_dgv.Columns["colApp_metal_oven_low"].DataPropertyName = "App_metal_oven_low";
            production_controller_detail_dgv.Columns["colApp_fundou_ng"].DataPropertyName = "App_fundou_ng";
            production_controller_detail_dgv.Columns["colApp_ter_glue_sticky"].DataPropertyName = "App_ter_glue_sticky";
            production_controller_detail_dgv.Columns["colApp_lead_glue_sticky"].DataPropertyName = "App_lead_glue_sticky";

            production_controller_detail_dgv.Columns.Add("colEn2_lock", "Lock");
            production_controller_detail_dgv.Columns.Add("colEn2_cut", "Cut");
            production_controller_detail_dgv.Columns.Add("colEn2_chattering", "Chattering");
            production_controller_detail_dgv.Columns.Add("colEn2_insulation", "Insulation");
            production_controller_detail_dgv.Columns.Add("colEn2_open", "Open");
            production_controller_detail_dgv.Columns.Add("colEn2_short", "Short");
            production_controller_detail_dgv.Columns.Add("colEn2_duty", "Duty");
            production_controller_detail_dgv.Columns.Add("colEn2_no", "No");
            production_controller_detail_dgv.Columns.Add("colEn2_var", "Var");
            production_controller_detail_dgv.Columns.Add("colEn2_reverse_spinning", "Reverse Spinning");
            production_controller_detail_dgv.Columns.Add("colEn2_starting_volt", "Starting Volt");
            production_controller_detail_dgv.Columns.Add("colEn2_io", "IO");

            production_controller_detail_dgv.Columns["colEn2_lock"].DataPropertyName = "En2_lock";
            production_controller_detail_dgv.Columns["colEn2_cut"].DataPropertyName = "En2_cut";
            production_controller_detail_dgv.Columns["colEn2_chattering"].DataPropertyName = "En2_chattering";
            production_controller_detail_dgv.Columns["colEn2_insulation"].DataPropertyName = "En2_insulation";
            production_controller_detail_dgv.Columns["colEn2_open"].DataPropertyName = "En2_open";
            production_controller_detail_dgv.Columns["colEn2_short"].DataPropertyName = "En2_short";
            production_controller_detail_dgv.Columns["colEn2_duty"].DataPropertyName = "En2_duty";
            production_controller_detail_dgv.Columns["colEn2_no"].DataPropertyName = "En2_no";
            production_controller_detail_dgv.Columns["colEn2_var"].DataPropertyName = "En2_var";
            production_controller_detail_dgv.Columns["colEn2_reverse_spinning"].DataPropertyName = "En2_reverse_spinning";
            production_controller_detail_dgv.Columns["colEn2_starting_volt"].DataPropertyName = "En2_starting_volt";
            production_controller_detail_dgv.Columns["colEn2_io"].DataPropertyName = "En2_io";

            production_controller_detail_dgv.Columns.Add("colFd_ng_beat_point", "Beat Point");
            production_controller_detail_dgv.Columns.Add("colFd_fundou_deform", "Deform");

            production_controller_detail_dgv.Columns["colFd_ng_beat_point"].DataPropertyName = "Fd_ng_beat_point";
            production_controller_detail_dgv.Columns["colFd_fundou_deform"].DataPropertyName = "Fd_fundou_deform";

            production_controller_detail_dgv.Columns.Add("colEn1_lock", "Lock");
            production_controller_detail_dgv.Columns.Add("colEn1_cut", "Cut");
            production_controller_detail_dgv.Columns.Add("colEn1_chattering", "Chattering");
            production_controller_detail_dgv.Columns.Add("colEn1_insulation", "Insulation");
            production_controller_detail_dgv.Columns.Add("colEn1_open", "Open");
            production_controller_detail_dgv.Columns.Add("colEn1_bad_wave", "Bad Wave");
            production_controller_detail_dgv.Columns.Add("colEn1_duty", "Duty");
            production_controller_detail_dgv.Columns.Add("colEn1_short", "Short");
            production_controller_detail_dgv.Columns.Add("colEn1_beat_case_ng", "Baet Case NG");
            production_controller_detail_dgv.Columns.Add("colEn1_beat_fundou_ng", "Fundou NG");

            production_controller_detail_dgv.Columns["colEn1_lock"].DataPropertyName = "En1_lock";
            production_controller_detail_dgv.Columns["colEn1_cut"].DataPropertyName = "En1_cut";
            production_controller_detail_dgv.Columns["colEn1_chattering"].DataPropertyName = "En1_chattering";
            production_controller_detail_dgv.Columns["colEn1_insulation"].DataPropertyName = "En1_insulation";
            production_controller_detail_dgv.Columns["colEn1_open"].DataPropertyName = "En1_open";
            production_controller_detail_dgv.Columns["colEn1_bad_wave"].DataPropertyName = "En1_bad_wave";
            production_controller_detail_dgv.Columns["colEn1_duty"].DataPropertyName = "En1_duty";
            production_controller_detail_dgv.Columns["colEn1_short"].DataPropertyName = "En1_short";
            production_controller_detail_dgv.Columns["colEn1_beat_case_ng"].DataPropertyName = "En1_beat_case_ng";
            production_controller_detail_dgv.Columns["colEn1_beat_fundou_ng"].DataPropertyName = "En1_beat_fundou_ng";

            production_controller_detail_dgv.Columns.Add("colInsc_no_ink_case_mc1", "No Ink Case");
            production_controller_detail_dgv.Columns.Add("colInsc_ba_deform_mc1", "Ba Deform");
            production_controller_detail_dgv.Columns.Add("colInsc_break_case_mc1", "Break Case");
            production_controller_detail_dgv.Columns.Add("colInsc_drop_mc1", "Drop");
            production_controller_detail_dgv.Columns.Add("colInsc_break_wire_mc1", "Break Wire");
            production_controller_detail_dgv.Columns.Add("colInsc_break_ring_mc1", "Break Ring");

            production_controller_detail_dgv.Columns["colInsc_no_ink_case_mc1"].DataPropertyName = "Insc_no_ink_case_mc1";
            production_controller_detail_dgv.Columns["colInsc_ba_deform_mc1"].DataPropertyName = "Insc_ba_deform_mc1";
            production_controller_detail_dgv.Columns["colInsc_break_case_mc1"].DataPropertyName = "Insc_break_case_mc1";
            production_controller_detail_dgv.Columns["colInsc_drop_mc1"].DataPropertyName = "Insc_drop_mc1";
            production_controller_detail_dgv.Columns["colInsc_break_wire_mc1"].DataPropertyName = "Insc_break_wire_mc1";
            production_controller_detail_dgv.Columns["colInsc_break_ring_mc1"].DataPropertyName = "Insc_break_ring_mc1";

            production_controller_detail_dgv.Columns.Add("colRA_com_pb_sticky", "Com Pb Stciky");
            production_controller_detail_dgv.Columns.Add("colRA_wire_pb_sticky", "Wire Pb Sticky");
            production_controller_detail_dgv.Columns.Add("colRA_com_slip", "Com Slip");
            production_controller_detail_dgv.Columns.Add("colRA_renew_ring", "Renew Ring");
            production_controller_detail_dgv.Columns.Add("colRA_break_wire_final_app", "Break Wire Final App");
            production_controller_detail_dgv.Columns.Add("colRA_wire_combine_wrong", "Wire Combine Wrong");
            production_controller_detail_dgv.Columns.Add("colRA_core_ng", "Core NG");
            production_controller_detail_dgv.Columns.Add("colRA_segment_hole", "Segment Hole");
            production_controller_detail_dgv.Columns.Add("colRA_glue_sticky", "Glue Sticky");
            production_controller_detail_dgv.Columns.Add("colRA_loose_wire_final_app", "Loose Wire Final App");
            production_controller_detail_dgv.Columns.Add("colRA_lead_not_covered", "Lead Not Covered");
            production_controller_detail_dgv.Columns.Add("colRA_less_lead", "Less Lead");

            production_controller_detail_dgv.Columns["colRA_com_pb_sticky"].DataPropertyName = "RA_com_pb_sticky";
            production_controller_detail_dgv.Columns["colRA_wire_pb_sticky"].DataPropertyName = "RA_wire_pb_sticky";
            production_controller_detail_dgv.Columns["colRA_com_slip"].DataPropertyName = "RA_com_slip";
            production_controller_detail_dgv.Columns["colRA_renew_ring"].DataPropertyName = "RA_renew_ring";
            production_controller_detail_dgv.Columns["colRA_break_wire_final_app"].DataPropertyName = "RA_break_wire_final_app";
            production_controller_detail_dgv.Columns["colRA_wire_combine_wrong"].DataPropertyName = "RA_wire_combine_wrong";
            production_controller_detail_dgv.Columns["colRA_core_ng"].DataPropertyName = "RA_core_ng";
            production_controller_detail_dgv.Columns["colRA_segment_hole"].DataPropertyName = "RA_segment_hole";
            production_controller_detail_dgv.Columns["colRA_glue_sticky"].DataPropertyName = "RA_glue_sticky";
            production_controller_detail_dgv.Columns["colRA_loose_wire_final_app"].DataPropertyName = "RA_loose_wire_final_app";
            production_controller_detail_dgv.Columns["colRA_lead_not_covered"].DataPropertyName = "RA_lead_not_covered";
            production_controller_detail_dgv.Columns["colRA_less_lead"].DataPropertyName = "RA_less_lead";

            production_controller_detail_dgv.Columns.Add("colRigs_wire_pb_sticky", "Wire Pb Sticky");
            production_controller_detail_dgv.Columns.Add("colRigs_com_pb_sticky", "Com Pb Sticky");
            production_controller_detail_dgv.Columns.Add("colRigs_ring_prone", "Ring Prone");
            production_controller_detail_dgv.Columns.Add("colRigs_cracked_ring", "Cracked Ring");

            production_controller_detail_dgv.Columns["colRigs_wire_pb_sticky"].DataPropertyName = "Rigs_wire_pb_sticky";
            production_controller_detail_dgv.Columns["colRigs_com_pb_sticky"].DataPropertyName = "Rigs_com_pb_sticky";
            production_controller_detail_dgv.Columns["colRigs_ring_prone"].DataPropertyName = "Rigs_ring_prone";
            production_controller_detail_dgv.Columns["colRigs_cracked_ring"].DataPropertyName = "Rigs_cracked_ring";

            production_controller_detail_dgv.Columns.Add("colPbs_break_copper", "Break Copper");
            production_controller_detail_dgv.Columns.Add("colPbs_climb_core", "Climb Core");
            production_controller_detail_dgv.Columns.Add("colPbs_skip_edge", "Skip Edge");
            production_controller_detail_dgv.Columns.Add("colPbs_wire_combine_wrong", "Wire Combine Wrong");
            production_controller_detail_dgv.Columns.Add("colPbs_loose_wire", "Loose Wire");
            production_controller_detail_dgv.Columns.Add("colPbs_rizer_edge_ng", "Rizer Edge NG");
            production_controller_detail_dgv.Columns.Add("colPbs_core_ng", "Core NG");
            production_controller_detail_dgv.Columns.Add("colPbs_com_slip", "Com Slip");
            production_controller_detail_dgv.Columns.Add("colPbs_hole", "Hole");
            production_controller_detail_dgv.Columns.Add("colPbs_2_sleeve", "2 Sleeve");
            production_controller_detail_dgv.Columns.Add("colPbs_wire_pb_sticky", "Wire Pb Sticky");
            production_controller_detail_dgv.Columns.Add("colPbs_com_pb_sticky", "Com Pb Sticky");
            production_controller_detail_dgv.Columns.Add("colPbs_no_lead", "No Lead");

            production_controller_detail_dgv.Columns["colPbs_break_copper"].DataPropertyName = "Pbs_break_copper";
            production_controller_detail_dgv.Columns["colPbs_climb_core"].DataPropertyName = "Pbs_climb_core";
            production_controller_detail_dgv.Columns["colPbs_skip_edge"].DataPropertyName = "Pbs_skip_edge";
            production_controller_detail_dgv.Columns["colPbs_wire_combine_wrong"].DataPropertyName = "Pbs_wire_combine_wrong";
            production_controller_detail_dgv.Columns["colPbs_loose_wire"].DataPropertyName = "Pbs_loose_wire";
            production_controller_detail_dgv.Columns["colPbs_rizer_edge_ng"].DataPropertyName = "Pbs_rizer_edge_ng";
            production_controller_detail_dgv.Columns["colPbs_core_ng"].DataPropertyName = "Pbs_core_ng";
            production_controller_detail_dgv.Columns["colPbs_com_slip"].DataPropertyName = "Pbs_com_slip";
            production_controller_detail_dgv.Columns["colPbs_hole"].DataPropertyName = "Pbs_hole";
            production_controller_detail_dgv.Columns["colPbs_2_sleeve"].DataPropertyName = "Pbs_2_sleeve";
            production_controller_detail_dgv.Columns["colPbs_wire_pb_sticky"].DataPropertyName = "Pbs_wire_pb_sticky";
            production_controller_detail_dgv.Columns["colPbs_com_pb_sticky"].DataPropertyName = "Pbs_com_pb_sticky";
            production_controller_detail_dgv.Columns["colPbs_no_lead"].DataPropertyName = "Pbs_no_lead";

            production_controller_detail_dgv.Columns.Add("colWi_break_copper_mc", "Break Copper");
            production_controller_detail_dgv.Columns.Add("colWi_ruffle_copper_mc", "Rufle Copper");
            production_controller_detail_dgv.Columns.Add("colWi_edge_ng_mc", "Edge NG");
            production_controller_detail_dgv.Columns.Add("colWi_no_sleeve_mc", "No Sleeve");

            production_controller_detail_dgv.Columns["colWi_break_copper_mc"].DataPropertyName = "Wi_break_copper_mc";
            production_controller_detail_dgv.Columns["colWi_ruffle_copper_mc"].DataPropertyName = "Wi_ruffle_copper_mc";
            production_controller_detail_dgv.Columns["colWi_edge_ng_mc"].DataPropertyName = "Wi_edge_ng_mc";
            production_controller_detail_dgv.Columns["colWi_no_sleeve_mc"].DataPropertyName = "Wi_no_sleeve_mc";

            production_controller_detail_dgv.Columns.Add("colWe_com_slip", "Com Slip");
            production_controller_detail_dgv.Columns.Add("colWe_long_shaft", "Long Shaft");
            production_controller_detail_dgv.Columns.Add("colWe_short_shaft", "Short Shart");

            production_controller_detail_dgv.Columns["colWe_com_slip"].DataPropertyName = "We_com_slip";
            production_controller_detail_dgv.Columns["colWe_long_shaft"].DataPropertyName = "We_long_shaft";
            production_controller_detail_dgv.Columns["colWe_short_shaft"].DataPropertyName = "We_short_shaft";

            production_controller_detail_dgv.Columns.Add("colCo_beat_core_ng", "Beat Core NG");
            production_controller_detail_dgv.Columns.Add("colCo_com_wrap", "Com Wrap");
            production_controller_detail_dgv.Columns.Add("colCo_core_ng", "Core");
            production_controller_detail_dgv.Columns.Add("colCo_com_glue_sticky", "Com Glue Sticky");

            production_controller_detail_dgv.Columns["colCo_beat_core_ng"].DataPropertyName = "Co_beat_core_ng";
            production_controller_detail_dgv.Columns["colCo_com_wrap"].DataPropertyName = "Co_com_wrap";
            production_controller_detail_dgv.Columns["colCo_core_ng"].DataPropertyName = "Co_core_ng";
            production_controller_detail_dgv.Columns["colCo_com_glue_sticky"].DataPropertyName = "Co_com_glue_sticky";

        }
        private void GridBindByAllLineAllprocess(string _datefrom, string _dateto)
        {
            production_controller_detail_dgv.DataSource = null;
            production_controller_detail_dgv.Columns.Clear();
            try
            {
                CreateAllColumnDGV();
                ProductionControllerVo vo = new ProductionControllerVo
                {
                    DateFrom = _datefrom,
                    DateTo = _dateto
                };
                ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineAllProcessCbm(), vo);

                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    production_controller_detail_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    production_controller_detail_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void GridBindByEachLineAllprocess(string _datefrom, string _dateto, string _line)
        {
            production_controller_detail_dgv.DataSource = null;
            production_controller_detail_dgv.Columns.Clear();
            try
            {
                CreateAllColumnDGV();
                ProductionControllerVo vo = new ProductionControllerVo
                {
                    DateFrom = _datefrom,
                    DateTo = _dateto,
                    ProLine = _line
                };
                ValueObjectList<ProductionControllerVo> volist = (ValueObjectList<ProductionControllerVo>)DefaultCbmInvoker.Invoke(new SearchProDetailEachLineAllProcessCbm(), vo);

                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    production_controller_detail_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    production_controller_detail_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
    }
}
