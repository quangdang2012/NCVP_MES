using Com.Nidec.Mes.Framework;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ProductionControllerDetailNCVCForm : FormCommonNCVP
    {
        public ProductionControllerDetailNCVCForm()
        {
            InitializeComponent();
        }
        public string _process;
        public string _model;
        public string _line;
        public string _dates;
        public string datefrom;
        public string dateto;

        public ProductionControllerDetailNCVCForm(string process, string model, string line, string dates) : this()
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
            
            if (_process == "Final_App")
            {
                production_controller_detail_dgv.Columns.Add("colFc_endplay_small", "End Play Small");
                production_controller_detail_dgv.Columns.Add("colFc_endplay_big", "End Play Big");
                production_controller_detail_dgv.Columns.Add("colFc_shaft_scracth", "Shaft Scracth");
                production_controller_detail_dgv.Columns.Add("colFc_terminal_low", "Terminal Low");
                production_controller_detail_dgv.Columns.Add("colFc_case_scracth_dirty", "Case Scracth Dirty");
                production_controller_detail_dgv.Columns.Add("colFc_pinion_worm_ng", "Pinion Worm NG");
                production_controller_detail_dgv.Columns.Add("colFc_shaft_lock", "Shaft Lock");
                production_controller_detail_dgv.Columns.Add("colFc_ba_deform", "Ba Deform");
                production_controller_detail_dgv.Columns.Add("colFc_tape_hole_deform", "Tape Hole Deform");
                production_controller_detail_dgv.Columns.Add("colFc_brush_rust", "Brush Rust");
                production_controller_detail_dgv.Columns.Add("colFc_metal_deform_scracth", "Metal Deform Scracth");
                production_controller_detail_dgv.Columns.Add("colFc_washer_tape_hole", "Washer Tape Hole");

                production_controller_detail_dgv.Columns["colFc_endplay_small"].DataPropertyName = "FC_endplay_small";
                production_controller_detail_dgv.Columns["colFc_endplay_big"].DataPropertyName = "FC_endplay_big";
                production_controller_detail_dgv.Columns["colFc_shaft_scracth"].DataPropertyName = "FC_shaft_scracth";
                production_controller_detail_dgv.Columns["colFc_terminal_low"].DataPropertyName = "FC_terminal_low";
                production_controller_detail_dgv.Columns["colFc_case_scracth_dirty"].DataPropertyName = "FC_case_scracth_dirty";
                production_controller_detail_dgv.Columns["colFc_pinion_worm_ng"].DataPropertyName = "FC_pinion_worm_ng";
                production_controller_detail_dgv.Columns["colFc_shaft_lock"].DataPropertyName = "FC_shaft_lock";
                production_controller_detail_dgv.Columns["colFc_ba_deform"].DataPropertyName = "FC_deform";
                production_controller_detail_dgv.Columns["colFc_tape_hole_deform"].DataPropertyName = "FC_tape_hole_deform";
                production_controller_detail_dgv.Columns["colFc_brush_rust"].DataPropertyName = "FC_brush_rust";
                production_controller_detail_dgv.Columns["colFc_metal_deform_scracth"].DataPropertyName = "FC_metal_deform_scracth";
                production_controller_detail_dgv.Columns["colFc_washer_tape_hole"].DataPropertyName = "FC_washer_tape_hole";
            }
            else if (_process == "En2")
            {
                production_controller_detail_dgv.Columns.Add("colEn2_insulation_resistance_ng", "Insulation Resistance Ng");
                production_controller_detail_dgv.Columns.Add("colEn2_cut_coil_wire", "Cut Coil Wire");
                production_controller_detail_dgv.Columns.Add("colEn2_no_load_current_hight", "No Load Current Hight");
                production_controller_detail_dgv.Columns.Add("colEn2_ripple", "Ripple");
                production_controller_detail_dgv.Columns.Add("colEn2_chattering", "Chattering");
                production_controller_detail_dgv.Columns.Add("colEn2_lock", "Lock");
                production_controller_detail_dgv.Columns.Add("colEn2_open", "Open");
                production_controller_detail_dgv.Columns.Add("colEn2_no_load_speed_low", "No Load Speed Low");
                production_controller_detail_dgv.Columns.Add("colEn2_starting_voltage", "Starting Voltage");
                production_controller_detail_dgv.Columns.Add("colEn2_no_load_speed_high", "No Load Speep High");
                production_controller_detail_dgv.Columns.Add("colEn2_rotor_mix", "Rotor Mix");
                production_controller_detail_dgv.Columns.Add("colEn2_surge_volt_max", "Surge Volt Max");
                production_controller_detail_dgv.Columns.Add("colEn2_wrong_post_of_pole", "Wrong Post of Pole");
                production_controller_detail_dgv.Columns.Add("colEn2_err", "Err");
                production_controller_detail_dgv.Columns.Add("colEn2_noise", "Noise");

                production_controller_detail_dgv.Columns["colEn2_insulation_resistance_ng"].DataPropertyName = "En2_insulation_resistance_ng";
                production_controller_detail_dgv.Columns["colEn2_cut_coil_wire"].DataPropertyName = "En2_cut_coil_wire";
                production_controller_detail_dgv.Columns["colEn2_no_load_current_hight"].DataPropertyName = "En2_no_load_current_hight";
                production_controller_detail_dgv.Columns["colEn2_ripple"].DataPropertyName = "En2_ripple";
                production_controller_detail_dgv.Columns["colEn2_chattering"].DataPropertyName = "En2_chattering";
                production_controller_detail_dgv.Columns["colEn2_lock"].DataPropertyName = "En2_lock";
                production_controller_detail_dgv.Columns["colEn2_open"].DataPropertyName = "En2_open";
                production_controller_detail_dgv.Columns["colEn2_no_load_speed_low"].DataPropertyName = "En2_no_load_speed_low";
                production_controller_detail_dgv.Columns["colEn2_starting_voltage"].DataPropertyName = "En2_starting_voltage";
                production_controller_detail_dgv.Columns["colEn2_no_load_speed_high"].DataPropertyName = "En2_no_load_speed_high";
                production_controller_detail_dgv.Columns["colEn2_rotor_mix"].DataPropertyName = "En2_rotor_mix";
                production_controller_detail_dgv.Columns["colEn2_surge_volt_max"].DataPropertyName = "En2_surge_volt_max";
                production_controller_detail_dgv.Columns["colEn2_wrong_post_of_pole"].DataPropertyName = "En2_wrong_post_of_pole";
                production_controller_detail_dgv.Columns["colEn2_err"].DataPropertyName = "En2_err";
                production_controller_detail_dgv.Columns["colEn2_noise"].DataPropertyName = "En2_noise";
            }
            else if (_process == "TrustGap")
            {
                production_controller_detail_dgv.Columns.Add("colBa_tc_endplay_big", "Endplay Big");
                production_controller_detail_dgv.Columns.Add("colBa_tc_endplay_small", "Endplay Small");
                production_controller_detail_dgv.Columns.Add("colBa_tc_brush_bent", "Brush Bent");
                production_controller_detail_dgv.Columns.Add("colBa_tc_shaft_mix", "Shaft Mix");

                production_controller_detail_dgv.Columns["colBa_tc_endplay_big"].DataPropertyName = "BA_tc_endplay_big";
                production_controller_detail_dgv.Columns["colBa_tc_endplay_small"].DataPropertyName = "BA_tc_endplay_small";
                production_controller_detail_dgv.Columns["colBa_tc_brush_bent"].DataPropertyName = "BA_tc_brush_bent";
                production_controller_detail_dgv.Columns["colBa_tc_shaft_mix"].DataPropertyName = "BA_tc_shaft_mix";
            }
            else if (_process == "En1")
            {
                production_controller_detail_dgv.Columns.Add("colEn1_insulation_resistace_ng", "Insulation Resistace Ng");
                production_controller_detail_dgv.Columns.Add("colEn1_cut_coil_wire", "Cut Coil Wire");
                production_controller_detail_dgv.Columns.Add("colEn1_lock", "Lock");
                production_controller_detail_dgv.Columns.Add("colEn1_wareform_ma_abnormal", "Wareform MA Abnormal");
                production_controller_detail_dgv.Columns.Add("colEn1_shaft_bent", "Shaft Bent");
                production_controller_detail_dgv.Columns.Add("colEn1_ripple", "Ripple");
                production_controller_detail_dgv.Columns.Add("colEn1_short", "Short");
                production_controller_detail_dgv.Columns.Add("colEn1_chattering", "Chattering");
                production_controller_detail_dgv.Columns.Add("colEn1_no_load_current_high", "No Load Current High");
                production_controller_detail_dgv.Columns.Add("colEn1_vibration_ng", "Vibration NG");
                production_controller_detail_dgv.Columns.Add("colEn1_open", "Open");
                production_controller_detail_dgv.Columns.Add("colEn1_rotor_mix", "Rotor Mix");

                production_controller_detail_dgv.Columns["colEn1_insulation_resistace_ng"].DataPropertyName = "En1_insulation_resistace_ng";
                production_controller_detail_dgv.Columns["colEn1_cut_coil_wire"].DataPropertyName = "En1_cut_coil_wire";
                production_controller_detail_dgv.Columns["colEn1_lock"].DataPropertyName = "En1_lock";
                production_controller_detail_dgv.Columns["colEn1_wareform_ma_abnormal"].DataPropertyName = "En1_wareform_ma_abnormal";
                production_controller_detail_dgv.Columns["colEn1_shaft_bent"].DataPropertyName = "En1_shaft_bent";
                production_controller_detail_dgv.Columns["colEn1_ripple"].DataPropertyName = "En1_ripple";
                production_controller_detail_dgv.Columns["colEn1_short"].DataPropertyName = "En1_short";
                production_controller_detail_dgv.Columns["colEn1_chattering"].DataPropertyName = "En1_chattering";
                production_controller_detail_dgv.Columns["colEn1_no_load_current_high"].DataPropertyName = "En1_no_load_current_high";
                production_controller_detail_dgv.Columns["colEn1_vibration_ng"].DataPropertyName = "En1_vibration_ng";
                production_controller_detail_dgv.Columns["colEn1_open"].DataPropertyName = "En1_open";
                production_controller_detail_dgv.Columns["colEn1_rotor_mix"].DataPropertyName = "En1_rotor_mix";
            }
            else if (_process == "Rotor")
            {
                production_controller_detail_dgv.Columns.Add("colBa_rto_ng", "Rotor NG");
                production_controller_detail_dgv.Columns.Add("colBa_rto_mix", "Rotor Mix");

                production_controller_detail_dgv.Columns["colBa_rto_ng"].DataPropertyName = "BA_rto_ng";
                production_controller_detail_dgv.Columns["colBa_rto_mix"].DataPropertyName = "BA_rto_mix";
            }
            else if (_process == "Bracket")
            {
                production_controller_detail_dgv.Columns.Add("colBa_app_metal_deform_scracth", "Metal Deform Scracth");
                production_controller_detail_dgv.Columns.Add("colBa_app_Ba_deform", "Ba Deform");
                production_controller_detail_dgv.Columns.Add("colBa_app_endplate_deform_scracth", "Endplate Deform Scracth");
                production_controller_detail_dgv.Columns.Add("colBa_app_error_other", "Error Other");

                production_controller_detail_dgv.Columns["colBa_app_metal_deform_scracth"].DataPropertyName = "BA_app_metal_deform_scracth";
                production_controller_detail_dgv.Columns["colBa_app_Ba_deform"].DataPropertyName = "BA_app_deform";
                production_controller_detail_dgv.Columns["colBa_app_endplate_deform_scracth"].DataPropertyName = "BA_app_endplate_deform_scracth";
                production_controller_detail_dgv.Columns["colBa_app_error_other"].DataPropertyName = "BA_app_error_other";
            }
            else if (_process == "BracketMetal")
            {
                production_controller_detail_dgv.Columns.Add("colBa_bm_brush_deform_scracth", "Brush Deform Scracth");
                production_controller_detail_dgv.Columns.Add("colBa_bm_metal_deform_scracth", "Metal Deform Scracth");
                production_controller_detail_dgv.Columns.Add("colBa_bm_ba_deform", "BA Deform");
                production_controller_detail_dgv.Columns.Add("colBa_bm_endplay_deform_scracth", "Endplate Deform Scracth");

                production_controller_detail_dgv.Columns["colBa_bm_brush_deform_scracth"].DataPropertyName = "BA_bm_brush_deform_scracth";
                production_controller_detail_dgv.Columns["colBa_bm_metal_deform_scracth"].DataPropertyName = "BA_bm_metal_deform_scracth";
                production_controller_detail_dgv.Columns["colBa_bm_ba_deform"].DataPropertyName = "BA_bm_deform";
                production_controller_detail_dgv.Columns["colBa_bm_endplay_deform_scracth"].DataPropertyName = "BA_bm_endplay_deform_scracth";
            }
            else if (_process == "CaseAssy")
            {
                production_controller_detail_dgv.Columns.Add("colCa_app_metal_dirty", "Metal Dirty");
                production_controller_detail_dgv.Columns.Add("colCa_app_tape_hole_deform", "Tape Hole Deform");
                production_controller_detail_dgv.Columns.Add("colCa_app_metal_high", "Metal High");
                production_controller_detail_dgv.Columns.Add("colCa_app_case_deform_scracth", "Case Deform Scracth");
                production_controller_detail_dgv.Columns.Add("colCa_app_metal_deform_scratch", "Metal Deform Scratch");
                production_controller_detail_dgv.Columns.Add("colCa_app_magnet_broken", "Magnet Broken");

                production_controller_detail_dgv.Columns["colCa_app_metal_dirty"].DataPropertyName = "CA_app_metal_dirty";
                production_controller_detail_dgv.Columns["colCa_app_tape_hole_deform"].DataPropertyName = "CA_app_tape_hole_deform";
                production_controller_detail_dgv.Columns["colCa_app_metal_high"].DataPropertyName = "CA_app_metal_high";
                production_controller_detail_dgv.Columns["colCa_app_case_deform_scracth"].DataPropertyName = "CA_app_case_deform_scracth";
                production_controller_detail_dgv.Columns["colCa_app_metal_deform_scratch"].DataPropertyName = "CA_app_metal_deform_scratch";
                production_controller_detail_dgv.Columns["colCa_app_magnet_broken"].DataPropertyName = "CA_app_magnet_broken";
            }
            else if (_process == "CaseMG")
            {
                production_controller_detail_dgv.Columns.Add("colCa_mg_metal_deform_scratch", "Metal Deform Scratch");
                production_controller_detail_dgv.Columns.Add("colCa_mg_case_deform_scratch", "Case Deform Scratch");

                production_controller_detail_dgv.Columns["colCa_mg_metal_deform_scratch"].DataPropertyName = "CA_mg_metal_deform_scratch";
                production_controller_detail_dgv.Columns["colCa_mg_case_deform_scratch"].DataPropertyName = "CA_mg_case_deform_scratch";
            }
            else if (_process == "MGBonding")
            {
                production_controller_detail_dgv.Columns.Add("colCa_bonding_metal_deform_scratch", "Com Slip");
                production_controller_detail_dgv.Columns.Add("colCa_bonding_case_deform_scracth", "Long Shaft");

                production_controller_detail_dgv.Columns["colCa_bonding_metal_deform_scratch"].DataPropertyName = "We_com_slip";
                production_controller_detail_dgv.Columns["colCa_bonding_case_deform_scracth"].DataPropertyName = "We_long_shaft";
            }
        }
        private void GridBind()
        {
            production_controller_detail_dgv.DataSource = null;
            production_controller_detail_dgv.Columns.Clear();
            try
            {
                ProductionControllerNCVCVo vo = new ProductionControllerNCVCVo
                {
                    ProLine = _line,
                    ProModel = _model,
                    Date = _dates
                };
                CreateColumnDGV();
                if (_process == "Final_App")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailFinalAppNCVCCbm(), vo);

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
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailEn2NCVCCbm(), vo);

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
                else if (_process == "TrustGap")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailTrustGapNCVCCbm(), vo);

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
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailEn1NCVCCbm(), vo);

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
                else if (_process == "Rotor")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailRotorNCVCCbm(), vo);

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
                else if (_process == "Bracket")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailBracketNCVCCbm(), vo);

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
                else if (_process == "BracketMetal")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailBracketMetalNCVCCbm(), vo);

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
                else if (_process == "CaseAssy")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailCaseAssyNCVCCbm(), vo);

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
                else if (_process == "CaseMG")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailCaseMGNCVCCbm(), vo);

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
                else if (_process == "MGBonding")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailMGBondingNCVCCbm(), vo);

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

                ProductionControllerNCVCVo vo = new ProductionControllerNCVCVo
                {
                    DateFrom = _datefrom,
                    DateTo = _dateto,
                    ProModel = _model
                };
                CreateColumnDGV();
                if (_process == "Final_App")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineFinal_AppNCVCCbm(), vo);

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
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineEn2NCVCCbm(), vo);

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
                else if (_process == "TrustGap")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineTrustGapNCVCCbm(), vo);

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
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineEn1NCVCCbm(), vo);

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
                else if (_process == "Rotor")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineRotorNCVCCbm(), vo);

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
                else if (_process == "Bracket")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineBracketNCVCCbm(), vo);

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
                else if (_process == "BracketMetal")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineBracketMetalNCVCCbm(), vo);

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
                else if (_process == "CaseAssy")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineCaseAssyNCVCCbm(), vo);

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
                else if (_process == "CaseMG")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineCaseMGNCVCCbm(), vo);

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
                else if (_process == "MGBonding")
                {
                    ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineMGBondingNCVCCbm(), vo);

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
            ProductionControllerChart_CNCVCForm form = new ProductionControllerChart_CNCVCForm(ref  production_controller_detail_dgv ,model_txt.Text, line_txt.Text, process_txt.Text, confirm_status_C);
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

            production_controller_detail_dgv.Columns.Add("colFc_endplay_small", "End Play Small");
            production_controller_detail_dgv.Columns.Add("colFc_endplay_big", "End Play Big");
            production_controller_detail_dgv.Columns.Add("colFc_shaft_scracth", "Shaft Scracth");
            production_controller_detail_dgv.Columns.Add("colFc_terminal_low", "Terminal Low");
            production_controller_detail_dgv.Columns.Add("colFc_case_scracth_dirty", "Case Scracth Dirty");
            production_controller_detail_dgv.Columns.Add("colFc_pinion_worm_ng", "Pinion Worm NG");
            production_controller_detail_dgv.Columns.Add("colFc_shaft_lock", "Shaft Lock");
            production_controller_detail_dgv.Columns.Add("colFc_ba_deform", "Ba Deform");
            production_controller_detail_dgv.Columns.Add("colFc_tape_hole_deform", "Tape Hole Deform");
            production_controller_detail_dgv.Columns.Add("colFc_brush_rust", "Brush Rust");
            production_controller_detail_dgv.Columns.Add("colFc_metal_deform_scracth", "Metal Deform Scracth");
            production_controller_detail_dgv.Columns.Add("colFc_washer_tape_hole", "Washer Tape Hole");

            production_controller_detail_dgv.Columns["colFc_endplay_small"].DataPropertyName = "FC_endplay_small";
            production_controller_detail_dgv.Columns["colFc_endplay_big"].DataPropertyName = "FC_endplay_big";
            production_controller_detail_dgv.Columns["colFc_shaft_scracth"].DataPropertyName = "FC_shaft_scracth";
            production_controller_detail_dgv.Columns["colFc_terminal_low"].DataPropertyName = "FC_terminal_low";
            production_controller_detail_dgv.Columns["colFc_case_scracth_dirty"].DataPropertyName = "FC_case_scracth_dirty";
            production_controller_detail_dgv.Columns["colFc_pinion_worm_ng"].DataPropertyName = "FC_pinion_worm_ng";
            production_controller_detail_dgv.Columns["colFc_shaft_lock"].DataPropertyName = "FC_shaft_lock";
            production_controller_detail_dgv.Columns["colFc_ba_deform"].DataPropertyName = "FC_deform";
            production_controller_detail_dgv.Columns["colFc_tape_hole_deform"].DataPropertyName = "FC_tape_hole_deform";
            production_controller_detail_dgv.Columns["colFc_brush_rust"].DataPropertyName = "FC_brush_rust";
            production_controller_detail_dgv.Columns["colFc_metal_deform_scracth"].DataPropertyName = "FC_metal_deform_scracth";
            production_controller_detail_dgv.Columns["colFc_washer_tape_hole"].DataPropertyName = "FC_washer_tape_hole";


            production_controller_detail_dgv.Columns.Add("colEn2_insulation_resistance_ng", "En2 Insulation Resistance Ng");
            production_controller_detail_dgv.Columns.Add("colEn2_cut_coil_wire", "En2 Cut Coil Wire");
            production_controller_detail_dgv.Columns.Add("colEn2_no_load_current_hight", "En2 No Load Current Hight");
            production_controller_detail_dgv.Columns.Add("colEn2_ripple", "En2 Ripple");
            production_controller_detail_dgv.Columns.Add("colEn2_chattering", "En2 Chattering");
            production_controller_detail_dgv.Columns.Add("colEn2_lock", "En2 Lock");
            production_controller_detail_dgv.Columns.Add("colEn2_open", "En2 Open");
            production_controller_detail_dgv.Columns.Add("colEn2_no_load_speed_low", "En2 No Load Speed Low");
            production_controller_detail_dgv.Columns.Add("colEn2_starting_voltage", "En2 Starting Voltage");
            production_controller_detail_dgv.Columns.Add("colEn2_no_load_speed_high", "En2 No Load Speep High");
            production_controller_detail_dgv.Columns.Add("colEn2_rotor_mix", "En2 Rotor Mix");
            production_controller_detail_dgv.Columns.Add("colEn2_surge_volt_max", "En2 Surge Volt Max");
            production_controller_detail_dgv.Columns.Add("colEn2_wrong_post_of_pole", "En2 Wrong Post of Pole");
            production_controller_detail_dgv.Columns.Add("colEn2_err", "En2 Err");
            production_controller_detail_dgv.Columns.Add("colEn2_noise", "En2 Noise");

            production_controller_detail_dgv.Columns["colEn2_insulation_resistance_ng"].DataPropertyName = "En2_insulation_resistance_ng";
            production_controller_detail_dgv.Columns["colEn2_cut_coil_wire"].DataPropertyName = "En2_cut_coil_wire";
            production_controller_detail_dgv.Columns["colEn2_no_load_current_hight"].DataPropertyName = "En2_no_load_current_hight";
            production_controller_detail_dgv.Columns["colEn2_ripple"].DataPropertyName = "En2_ripple";
            production_controller_detail_dgv.Columns["colEn2_chattering"].DataPropertyName = "En2_chattering";
            production_controller_detail_dgv.Columns["colEn2_lock"].DataPropertyName = "En2_lock";
            production_controller_detail_dgv.Columns["colEn2_open"].DataPropertyName = "En2_open";
            production_controller_detail_dgv.Columns["colEn2_no_load_speed_low"].DataPropertyName = "En2_no_load_speed_low";
            production_controller_detail_dgv.Columns["colEn2_starting_voltage"].DataPropertyName = "En2_starting_voltage";
            production_controller_detail_dgv.Columns["colEn2_no_load_speed_high"].DataPropertyName = "En2_no_load_speed_high";
            production_controller_detail_dgv.Columns["colEn2_rotor_mix"].DataPropertyName = "En2_rotor_mix";
            production_controller_detail_dgv.Columns["colEn2_surge_volt_max"].DataPropertyName = "En2_surge_volt_max";
            production_controller_detail_dgv.Columns["colEn2_wrong_post_of_pole"].DataPropertyName = "En2_wrong_post_of_pole";
            production_controller_detail_dgv.Columns["colEn2_err"].DataPropertyName = "En2_err";
            production_controller_detail_dgv.Columns["colEn2_noise"].DataPropertyName = "En2_noise";

            production_controller_detail_dgv.Columns.Add("colBa_tc_endplay_big", "Endplay Big");
            production_controller_detail_dgv.Columns.Add("colBa_tc_endplay_small", "Endplay Small");
            production_controller_detail_dgv.Columns.Add("colBa_tc_brush_bent", "Brush Bent");
            production_controller_detail_dgv.Columns.Add("colBa_tc_shaft_mix", "Shaft Mix");

            production_controller_detail_dgv.Columns["colBa_tc_endplay_big"].DataPropertyName = "BA_tc_endplay_big";
            production_controller_detail_dgv.Columns["colBa_tc_endplay_small"].DataPropertyName = "BA_tc_endplay_small";
            production_controller_detail_dgv.Columns["colBa_tc_brush_bent"].DataPropertyName = "BA_tc_brush_bent";
            production_controller_detail_dgv.Columns["colBa_tc_shaft_mix"].DataPropertyName = "BA_tc_shaft_mix";

            production_controller_detail_dgv.Columns.Add("colEn1_insulation_resistace_ng", "En1 Insulation Resistace Ng");
            production_controller_detail_dgv.Columns.Add("colEn1_cut_coil_wire", "En1 Cut Coil Wire");
            production_controller_detail_dgv.Columns.Add("colEn1_lock", "En1 Lock");
            production_controller_detail_dgv.Columns.Add("colEn1_wareform_ma_abnormal", "En1 Wareform MA Abnormal");
            production_controller_detail_dgv.Columns.Add("colEn1_shaft_bent", "En1 Shaft Bent");
            production_controller_detail_dgv.Columns.Add("colEn1_ripple", "En1 Ripple");
            production_controller_detail_dgv.Columns.Add("colEn1_short", "En1 Short");
            production_controller_detail_dgv.Columns.Add("colEn1_chattering", "En1 Chattering");
            production_controller_detail_dgv.Columns.Add("colEn1_no_load_current_high", "En1 No Load Current High");
            production_controller_detail_dgv.Columns.Add("colEn1_vibration_ng", "En1 Vibration NG");
            production_controller_detail_dgv.Columns.Add("colEn1_open", "En1 Open");
            production_controller_detail_dgv.Columns.Add("colEn1_rotor_mix", "En1 Rotor Mix");

            production_controller_detail_dgv.Columns["colEn1_insulation_resistace_ng"].DataPropertyName = "En1_insulation_resistace_ng";
            production_controller_detail_dgv.Columns["colEn1_cut_coil_wire"].DataPropertyName = "En1_cut_coil_wire";
            production_controller_detail_dgv.Columns["colEn1_lock"].DataPropertyName = "En1_lock";
            production_controller_detail_dgv.Columns["colEn1_wareform_ma_abnormal"].DataPropertyName = "En1_wareform_ma_abnormal";
            production_controller_detail_dgv.Columns["colEn1_shaft_bent"].DataPropertyName = "En1_shaft_bent";
            production_controller_detail_dgv.Columns["colEn1_ripple"].DataPropertyName = "En1_ripple";
            production_controller_detail_dgv.Columns["colEn1_short"].DataPropertyName = "En1_short";
            production_controller_detail_dgv.Columns["colEn1_chattering"].DataPropertyName = "En1_chattering";
            production_controller_detail_dgv.Columns["colEn1_no_load_current_high"].DataPropertyName = "En1_no_load_current_high";
            production_controller_detail_dgv.Columns["colEn1_vibration_ng"].DataPropertyName = "En1_vibration_ng";
            production_controller_detail_dgv.Columns["colEn1_open"].DataPropertyName = "En1_open";
            production_controller_detail_dgv.Columns["colEn1_rotor_mix"].DataPropertyName = "En1_rotor_mix";

            production_controller_detail_dgv.Columns.Add("colBa_rto_ng", "Rotor NG");
            production_controller_detail_dgv.Columns.Add("colBa_rto_mix", "Rotor Mix");

            production_controller_detail_dgv.Columns["colBa_rto_ng"].DataPropertyName = "BA_rto_ng";
            production_controller_detail_dgv.Columns["colBa_rto_mix"].DataPropertyName = "BA_rto_mix";

            production_controller_detail_dgv.Columns.Add("colBa_app_metal_deform_scracth", "Metal Deform Scracth");
            production_controller_detail_dgv.Columns.Add("colBa_app_Ba_deform", "Ba Deform");
            production_controller_detail_dgv.Columns.Add("colBa_app_endplate_deform_scracth", "Endplate Deform Scracth");
            production_controller_detail_dgv.Columns.Add("colBa_app_error_other", "Error Other");

            production_controller_detail_dgv.Columns["colBa_app_metal_deform_scracth"].DataPropertyName = "BA_app_metal_deform_scracth";
            production_controller_detail_dgv.Columns["colBa_app_Ba_deform"].DataPropertyName = "BA_app_deform";
            production_controller_detail_dgv.Columns["colBa_app_endplate_deform_scracth"].DataPropertyName = "BA_app_endplate_deform_scracth";
            production_controller_detail_dgv.Columns["colBa_app_error_other"].DataPropertyName = "BA_app_error_other";

            production_controller_detail_dgv.Columns.Add("colBa_bm_brush_deform_scracth", "Brush Deform Scracth");
            production_controller_detail_dgv.Columns.Add("colBa_bm_metal_deform_scracth", "Metal Deform Scracth");
            production_controller_detail_dgv.Columns.Add("colBa_bm_ba_deform", "BA Deform");
            production_controller_detail_dgv.Columns.Add("colBa_bm_endplay_deform_scracth", "Endplate Deform Scracth");

            production_controller_detail_dgv.Columns["colBa_bm_brush_deform_scracth"].DataPropertyName = "BA_bm_brush_deform_scracth";
            production_controller_detail_dgv.Columns["colBa_bm_metal_deform_scracth"].DataPropertyName = "BA_bm_metal_deform_scracth";
            production_controller_detail_dgv.Columns["colBa_bm_ba_deform"].DataPropertyName = "BA_bm_deform";
            production_controller_detail_dgv.Columns["colBa_bm_endplay_deform_scracth"].DataPropertyName = "BA_bm_endplay_deform_scracth";

            production_controller_detail_dgv.Columns.Add("colCa_app_metal_dirty", "Metal Dirty");
            production_controller_detail_dgv.Columns.Add("colCa_app_tape_hole_deform", "Tape Hole Deform");
            production_controller_detail_dgv.Columns.Add("colCa_app_metal_high", "Metal High");
            production_controller_detail_dgv.Columns.Add("colCa_app_case_deform_scracth", "Case Deform Scracth");
            production_controller_detail_dgv.Columns.Add("colCa_app_metal_deform_scratch", "Metal Deform Scratch");
            production_controller_detail_dgv.Columns.Add("colCa_app_magnet_broken", "Magnet Broken");

            production_controller_detail_dgv.Columns["colCa_app_metal_dirty"].DataPropertyName = "CA_app_metal_dirty";
            production_controller_detail_dgv.Columns["colCa_app_tape_hole_deform"].DataPropertyName = "CA_app_tape_hole_deform";
            production_controller_detail_dgv.Columns["colCa_app_metal_high"].DataPropertyName = "CA_app_metal_high";
            production_controller_detail_dgv.Columns["colCa_app_case_deform_scracth"].DataPropertyName = "CA_app_case_deform_scracth";
            production_controller_detail_dgv.Columns["colCa_app_metal_deform_scratch"].DataPropertyName = "CA_app_metal_deform_scratch";
            production_controller_detail_dgv.Columns["colCa_app_magnet_broken"].DataPropertyName = "CA_app_magnet_broken";

            production_controller_detail_dgv.Columns.Add("colCa_mg_metal_deform_scratch", "Metal Deform Scratch");
            production_controller_detail_dgv.Columns.Add("colCa_mg_case_deform_scratch", "Case Deform Scratch");

            production_controller_detail_dgv.Columns["colCa_mg_metal_deform_scratch"].DataPropertyName = "CA_mg_metal_deform_scratch";
            production_controller_detail_dgv.Columns["colCa_mg_case_deform_scratch"].DataPropertyName = "CA_mg_case_deform_scratch";

            production_controller_detail_dgv.Columns.Add("colCa_bonding_metal_deform_scratch", "Com Slip");
            production_controller_detail_dgv.Columns.Add("colCa_bonding_case_deform_scracth", "Long Shaft");

            production_controller_detail_dgv.Columns["colCa_bonding_metal_deform_scratch"].DataPropertyName = "We_com_slip";
            production_controller_detail_dgv.Columns["colCa_bonding_case_deform_scracth"].DataPropertyName = "We_long_shaft";

        }
        private void GridBindByAllLineAllprocess(string _datefrom, string _dateto)
        {
            production_controller_detail_dgv.DataSource = null;
            production_controller_detail_dgv.Columns.Clear();
            try
            {
                CreateAllColumnDGV();
                ProductionControllerNCVCVo vo = new ProductionControllerNCVCVo
                {
                    DateFrom = _datefrom,
                    DateTo = _dateto,
                    ProModel = _model
                };
                ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailAllLineAllProcessNCVCCbm(), vo);

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
                ProductionControllerNCVCVo vo = new ProductionControllerNCVCVo
                {
                    DateFrom = _datefrom,
                    DateTo = _dateto,
                    ProLine = _line
                };
                ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchProDetailEachLineAllProcessNCVCCbm(), vo);

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
