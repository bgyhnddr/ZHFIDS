using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data;

namespace ZHFIDS
{
    public partial class Forms
    {
        public static FIDS FIDSForm { get; set; }
        public static Arrival ArrivalForm { get; set; }
        public static Carousel CarouselForm { get; set; }
        public static Carousel CarouseldForm { get; set; }
        public static Departure DepartureForm { get; set; }
        public static Editor EditorForm { get; set; }
        public static Gate GateForm { get; set; }
        public static Guide GuideForm { get; set; }
        public static Server ServerForm { get; set; }
        public static MainNotify NotifyForm { get; set; }

        public static void ChangeForm(global.SubsystemType type, bool force = false)
        {
            try
            {
                global.Variable.Subsystem = type;
                if (type != global.SubsystemType.FIDS)
                {
                    if (FIDSForm != null)
                    {
                        if (!FIDSForm.IsDisposed)
                        {
                            FIDSForm.Close();
                        }
                        FIDSForm = null;
                    }
                }
                else
                {
                    if (FIDSForm != null)
                    {
                        if (!FIDSForm.IsDisposed)
                        {
                            FIDSForm.Close();
                        }
                    }
                    FIDSForm = new FIDS();
                    FIDSForm.Show();
                }

                if (type != global.SubsystemType.arrival)
                {
                    if (ArrivalForm != null)
                    {
                        if (!ArrivalForm.IsDisposed)
                        {
                            ArrivalForm.Close();
                        }
                        ArrivalForm = null;
                    }
                }
                else
                {
                    if (ArrivalForm != null)
                    {
                        if (!ArrivalForm.IsDisposed)
                        {
                            ArrivalForm.Close();
                        }

                    }
                    ArrivalForm = new Arrival(false);
                    ArrivalForm.Show();
                }

                if (type != global.SubsystemType.carousel)
                {
                    if (CarouselForm != null)
                    {
                        if (!CarouselForm.IsDisposed)
                        {
                            CarouselForm.Close();
                        }
                        CarouselForm = null;
                    }
                }
                else
                {
                    if (CarouselForm != null)
                    {
                        if (!CarouselForm.IsDisposed)
                        {
                            CarouselForm.Close();
                        }
                    }
                    CarouselForm = new Carousel();
                    CarouselForm.Show();
                }

                if (type != global.SubsystemType.carouseld)
                {
                    if (CarouseldForm != null)
                    {
                        if (!CarouseldForm.IsDisposed)
                        {
                            CarouseldForm.Close();
                        }
                        CarouseldForm = null;
                    }
                }
                else
                {
                    if (CarouseldForm != null)
                    {
                        if (!CarouseldForm.IsDisposed)
                        {
                            CarouseldForm.Close();
                        }
                    }
                    CarouseldForm = new Carousel();
                    CarouseldForm.Show();
                }

                if (type != global.SubsystemType.departure)
                {
                    if (DepartureForm != null)
                    {
                        if (!DepartureForm.IsDisposed)
                        {
                            DepartureForm.Close();
                        }
                        DepartureForm = null;
                    }
                }
                else
                {
                    if (DepartureForm != null)
                    {
                        if (!DepartureForm.IsDisposed)
                        {
                            DepartureForm.Close();
                        }
                    }
                    DepartureForm = new Departure(false);
                    DepartureForm.Show();
                }

                if (type != global.SubsystemType.editor)
                {
                    if (EditorForm != null)
                    {
                        if (!EditorForm.IsDisposed)
                        {
                            EditorForm.Close();
                        }
                        EditorForm = null;
                    }
                }
                else
                {
                    if (EditorForm != null)
                    {
                        if (!EditorForm.IsDisposed)
                        {
                            EditorForm.Close();
                        }
                    }
                    EditorForm = new Editor();
                    EditorForm.Show();
                }

                if (type != global.SubsystemType.gate)
                {
                    if (GateForm != null)
                    {
                        if (!GateForm.IsDisposed)
                        {
                            GateForm.Close();
                        }
                        GateForm = null;
                    }
                }
                else
                {
                    if (GateForm != null)
                    {
                        if (!GateForm.IsDisposed)
                        {
                            GateForm.Close();
                        }
                    }
                    GateForm = new Gate();
                    GateForm.Show();
                }

                if (type != global.SubsystemType.guide)
                {
                    if (GuideForm != null)
                    {
                        if (!GuideForm.IsDisposed)
                        {
                            GuideForm.Close();
                        }
                        GuideForm = null;
                    }
                }
                else
                {
                    if (GuideForm != null)
                    {
                        if (GuideForm.IsDisposed)
                        {
                            GuideForm.Close();
                        }
                    }
                    GuideForm = new Guide(false);
                    GuideForm.Show();
                }

                if (type != global.SubsystemType.server)
                {
                    if (ServerForm != null)
                    {
                        if (!ServerForm.IsDisposed)
                        {
                            ServerForm.Close();
                        }
                        ServerForm = null;
                    }
                }
                else
                {
                    if (ServerForm != null)
                    {
                        if (!ServerForm.IsDisposed)
                        {
                            ServerForm.Close();
                        }
                    }
                    ServerForm = new Server();
                    ServerForm.Show();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(global.Const.CHANGEFORMERROR, ex);
            }
        }
    }
}
