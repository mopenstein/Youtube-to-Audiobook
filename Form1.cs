using Ini;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Youtube_Video_to_Audio
{
    public partial class Form1 : Form
    {

        private IniFile ini = new IniFile(AppDomain.CurrentDomain.BaseDirectory + "\\options.ini");

        public string GetURL(string url)
        {
            try
            {
                string lua_lastHeader = "";
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse WebResponse = (HttpWebResponse)req.GetResponse();
                WebHeaderCollection header = WebResponse.Headers;

                for (int i = 0; i < header.Count; i++)
                    lua_lastHeader += header.GetKey(i) + ":" + header[i] + "\n";

                Stream responseStream = WebResponse.GetResponseStream();
                if (lua_lastHeader.ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }
                else if (lua_lastHeader.ToLower().Contains("deflate"))
                {
                    responseStream.ReadByte();
                    responseStream.ReadByte();
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                }

                StreamReader Reader = new StreamReader(responseStream, Encoding.Default);

                string Html = Reader.ReadToEnd();

                WebResponse.Close();
                responseStream.Close();

                return Html;

            }
            catch
            {
                return null;
            }
        }

        public string str_unescape(string s)
        {
            return Uri.UnescapeDataString(s);
        }

        public string str_get_between(string str, string first, string second, int start)
        {
            try
            {
                int a = 0;
                if (first == null)
                {
                    a = 0;
                    first = "";
                }
                else if (first != "") a = str.IndexOf(first, start);
                if (a == -1) { return null; }

                int b = 0;
                if (second == null)
                {
                    b = str.Length;
                    second = "";
                }
                else if (second != "") b = str.IndexOf(second, a + first.Length);
                if (b == -1) { return null; }

                return str.Substring(a + first.Length, b - a - first.Length);
            }
            catch
            {
                return null;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        public string lua_GetTime(string type)
        {
            TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            double u = Math.Floor(ts.TotalSeconds);
            System.DateTime n = DateTime.Now;
            string tz = "";
            if (System.TimeZone.CurrentTimeZone.IsDaylightSavingTime(n) == true)
            {
                tz = System.TimeZone.CurrentTimeZone.DaylightName;
            }
            else
            {
                tz = System.TimeZone.CurrentTimeZone.StandardName;
            }

            string t = type;
            t = t.Replace("utc", u.ToString());
            t = t.Replace("now", n.ToString());
            t = t.Replace("hour", n.Hour.ToString());
            t = t.Replace("minute", n.Minute.ToString());
            t = t.Replace("millisecond", n.Millisecond.ToString());
            t = t.Replace("second", n.Second.ToString());
            t = t.Replace("ticks", n.Ticks.ToString());
            t = t.Replace("dayofweek", n.DayOfWeek.ToString().Replace("day", "XdXaXyX"));
            t = t.Replace("dayofyear", n.DayOfYear.ToString());
            t = t.Replace("kind", n.Kind.ToString());
            t = t.Replace("day", n.Day.ToString());
            t = t.Replace("month", n.Month.ToString());
            t = t.Replace("year", n.Year.ToString());
            t = t.Replace("timezone", tz);
            return t.Replace("XdXaXyX", "day");
        }

        public void log(string a, string error = null, bool debug = false)
        {
            if (chkLog.Checked != true && debug == true) return;
            if (error != null) txtDebug.AppendText(lua_GetTime("now") + ": " + "-------" + error + "-------\r\n");
                txtDebug.AppendText(lua_GetTime("now") + ": " + a + "\r\n");
            if (error != null) txtDebug.AppendText(lua_GetTime("now") + ": " + "-------" + error + "-------\r\n");
        }

        public string[] getYouTubeURL(string id)
        {
            try
            {
                string tmp = GetURL("http://youtube.com/get_video_info?video_id=" + id);

                    if (tmp==null) return new string[] { null, "Couldn't get Youtube info" };

                log(tmp, null, true);
                string[] splt = tmp.Split('&');
                string furl = "";
                string title = null;
                string thumbnail = null;

                for (int y = 0; y < splt.Length; y++)
                {
                    
                    string suy = str_unescape(splt[y]);
                    log(suy, null, true);
                    if (suy.StartsWith("url_encoded_fmt_stream_map"))
                    {
                        string[] spltX = suy.Split(new Char[] { '&', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int yx = 0; yx < spltX.Length; yx++)
                        {
                            string syx = str_unescape(spltX[yx]);
                            if (syx.IndexOf("mime=video%2Fmp4") > -1) furl = syx.Substring(4);
                            log("\t" + syx, null, true);
                        }
                    }
                    else if (suy.StartsWith("title"))
                    {
                        title = str_get_between(suy, "title=", null, 0);
                        if(title!=null)
                        {
                            title = Regex.Replace(title, @"[^a-zA-Z0-9]+", " ");
                            title = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
                        }
                    }
                    else if (suy.StartsWith("thumbnail_url"))
                    {
                        thumbnail = str_get_between(suy, "thumbnail_url=", null, 0);
                    }
                }

                if (title == null) throw new Exception("Could not find Title!");

                
                
                return new string[] { furl, str_unescape(title).Replace('+', ' '), thumbnail };
            }
            catch(Exception e)
            {
                return new string[] { null, e.ToString() };
            }
        }

        public bool downloading = false;

        public bool downloadFile(string url, string file_location, string file_name)
        {
            try
            {
                log("Starting video download...");
                downloading = true;
                string lua_lastHeader = "";
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);

                Uri refURL = new Uri(url);
                req.Referer = refURL.Host;
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.97 Safari/537.11";

                HttpWebResponse WebResponse = (HttpWebResponse)req.GetResponse();
                WebHeaderCollection header = WebResponse.Headers;

                for (int i = 0; i < header.Count; i++)
                {
                    log("Header: " + header.GetKey(i) + ":" + header[i], null, true);
                    lua_lastHeader += header.GetKey(i) + ":" + header[i] + "\n";
                }

                

                string len = str_get_between(lua_lastHeader, "Content-Length:", "\n", 0);
                //2658508238
                if (len.Length > 9)
                {
                    progressBar1.Maximum = 2147483647;
                    progressBar1.Value = 0;
                }
                else
                {
                    progressBar1.Maximum = Int32.Parse(len);
                    progressBar1.Value = 0;
                }

                using (Stream responseStream = WebResponse.GetResponseStream())
                {
                    //lvwURLs.Items[item_num].SubItems[1].Text = fileName;
                    log(file_name, null, true);
                    using (Stream fileStream = File.OpenWrite(file_location + "\\" + file_name))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead = responseStream.Read(buffer, 0, 4096);
                        int time = Int32.Parse(lua_GetTime("utc"));

                        while (bytesRead > 0)
                        {
                            if (downloading == false) return false;
                            DateTime startTime = DateTime.UtcNow;

                            Application.DoEvents();
                            fileStream.Write(buffer, 0, bytesRead);
                            bytesRead = responseStream.Read(buffer, 0, 4096);
                            if (progressBar1.Value + 4096 > progressBar1.Maximum)
                            {
                                progressBar1.Value = progressBar1.Maximum;
                            }
                            else progressBar1.Value += 4096;


                            int ctime = Int32.Parse(lua_GetTime("utc"));
                            int dtime = ctime - time;
                            TimeSpan tzz = TimeSpan.FromSeconds(((progressBar1.Maximum - progressBar1.Value) / ((double)progressBar1.Value / dtime)));

                            string ans = tzz.Minutes + "m:" + tzz.Seconds + "s";
                            this.Text = "YouTube to Audio - Remaining  " + ans + "";

                        }
                    }
                }
                log("Finished Downloading video.");
                downloading = false;
                this.Text = "YouTube to Audio";
                return true;
            }
            catch (Exception ex)
            {
                log(ex.ToString(), "Download Error");
                downloading = false;
                return false;
            }

        }

        public TimeSpan GetDuration(string filename)
        {
            string ffmpeg_location = txtFFMPEG.Text + "ffmpeg.exe";
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            proc.StartInfo.Arguments = "-i " + "\"" + filename + "\"" + "";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            if (!proc.Start())
            {
                Console.WriteLine("Error starting");
            }
            StreamReader reader = proc.StandardError;
            string line;
            TimeSpan ts = new TimeSpan();

            while ((line = reader.ReadLine()) != null)
            {

                int a = line.IndexOf("Duration");
                if (a >= 0)
                {
                    int b = line.IndexOf(".", a + 1);
                    string dur = line.Substring(a + 10, b - a - 10);

                    TimeSpan.TryParse(dur, out ts);
                    return ts;
                }


                Application.DoEvents();
            }

            return ts;
        }

        string[] ytinfo_vid;

        private void preDownload(string ytid)
        {
            TagLib.Id3v2.Tag.DefaultVersion = 3;
            TagLib.Id3v2.Tag.ForceDefaultVersion = true;

            ytinfo_vid = getYouTubeURL(ytid);
            if (ytinfo_vid[0] == null)
            {
                log(ytinfo_vid[1], "YouTube Error");

                return;
            }
            txtTitle.Text = ytinfo_vid[1];
            txtTitle.Tag = txtSavePath.Text + Regex.Replace(ytinfo_vid[1], @"[^a-zA-Z0-9]+", "_") + ".jpg";

            if (ytinfo_vid[2] != null)
            {
                picThumb.Load(ytinfo_vid[2]);
                picThumb.Image.Save(txtTitle.Tag.ToString());
            }

            log("Youtube URL: " + ytinfo_vid[0], null, true);
            log("Youtube Title: " + ytinfo_vid[1]);
        }

        private const string YoutubeLinkRegex = "(?:.+?)?(?:\\/v\\/|watch\\/|\\?v=|\\&v=|youtu\\.be\\/|\\/v=|^youtu\\.be\\/)([a-zA-Z0-9_-]{11})+";
        private static Regex regexExtractId = new Regex(YoutubeLinkRegex, RegexOptions.Compiled);
        private static string[] validAuthorities = { "youtube.com", "www.youtube.com", "youtu.be", "www.youtu.be" };

        public string ExtractVideoIdFromUri(Uri uri)
        {
            try
            {
                string authority = new UriBuilder(uri).Uri.Authority.ToLower();

                //check if the url is a youtube url
                if (validAuthorities.Contains(authority))
                {
                    //and extract the id
                    var regRes = regexExtractId.Match(uri.ToString());
                    if (regRes.Success)
                    {
                        return regRes.Groups[1].Value;
                    }
                }
            }
            catch { }


            return null;
        }

        private int currStep = 0;

        private bool autoAccept = false;

        private void btnTest_Click(object sender, EventArgs e)
        {

            if(txtURL.Text == "" && lstQueue.Items.Count>0)
            {

                if (autoAccept == false)
                {
                    if (MessageBox.Show("There are multiple items in the Queue.\r\n\r\nWould you like to auto-accept all prompts?", "Auto Accept", MessageBoxButtons.YesNo) == DialogResult.Yes) autoAccept = true;
                }
                
                txtURL.Text = lstQueue.Items[0].ToString();
                lstQueue.Items.RemoveAt(0);
            }

            if (File.Exists(txtURL.Text)==true && currStep==0)
            {

                txtDebug.Text = "";
                if (chkVolume.Checked == true)
                {
                    detectVolume();
                }

                currStep = 2;
                downloading = false;
                btnTest.Text = "Stop";
                processFile(txtURL.Text);
                return;

            }

            if (currStep == 0)
            {
                txtDebug.Text = "";
                string url = txtURL.Text;
                Uri uri = null;
                if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                {
                    try
                    {
                        uri = new UriBuilder("http", url).Uri;
                    }
                    catch
                    {
                        log("Please provide a valid Youtube URL.", "Youtube Error");
                        return;
                    }
                }

                txtURL.Text = uri.ToString();
                string ytid = ExtractVideoIdFromUri(uri);
                if (txtURL.Text == "" || ytid==null)
                {
                    log("Please provide a valid Youtube URL.", "Youtube Error");
                    return;
                }


                preDownload(ytid);

                if (chkService.Checked == true)
                {
                    log("Using 3rd Party to fetch url.");
                    if(chkRandom.Checked==true)
                    {
                        cmbFetchers.SelectedIndex = new Random().Next(0, cmbFetchers.Items.Count);
                    }
                    ytinfo_vid[0] = fetchUrl(cmbFetchers.Text);

                    if(ytinfo_vid[0]==null)
                    {
                        log("Something went wrong. Cannot use 3rd Party service at this time.");
                    }
                    else
                    {
                        log("Got it!");
                    }
                    
                }

                currStep++;
                if (autoAccept == true)
                {
                    currStep = 2;
                }
                else
                {
                    if (MessageBox.Show("Does everything look good?\r\n\r\nIf not, you can make changes and start where you left off.", "Continue?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        log("User paused. Click the button again to continue.");
                        btnTest.Text = "Continue";
                        return;
                    }
                    else
                    {
                        currStep = 2;
                    }
                }
            }
            else if (currStep == 1)
            {
                currStep++;
                if (autoAccept == false)
                {
                    if (MessageBox.Show("You have already started a session.\n\nWould you like to continue with it?", "Continue?", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        log("User Canceled.");
                        currStep = 0;
                        btnTest.Text = "Start";
                        return;
                    }
                }
            }
            else if (currStep == 2)
            {
                currStep++;
                if (MessageBox.Show("Are you sure you want to stop?", "Stop?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    log("User Canceled.");
                    downloading = false;
                    currStep = 0;
                    btnTest.Text = "Start";
                    autoAccept = false;
                    return;
                }
                else
                {
                    return;
                }
            }

            btnTest.Text = "Stop";

            if (ytinfo_vid[0]== null)
            {
                log("No youtube information found.", "Download Error");
                return;
            }

            bool sucdl = downloadFile(ytinfo_vid[0], txtSavePath.Text, ytinfo_vid[1] + ".mp4");

            if(!sucdl)
            {
                log("Couldn't download file", "Download Error");
                return;
            }

            if (chkVolume.Checked == true)
            {
                detectVolume();
            }

            processFile(txtSavePath.Text + ytinfo_vid[1] + ".mp4");

            currStep = 0;
            btnTest.Text = "Start";
            log("Finished!");

            if (lstQueue.Items.Count > 0)
            {
                txtURL.Text = "";
                btnTest_Click(null, null);
            }
            else autoAccept = false;

        }

        public void processFile(string file)
        {
            

            /*
            string file = txtSavePath.Text + "Howard Stern - Channel 9 Show - Episode 27 (1991).mp4";
            lblTitle.Text = Path.GetFileNameWithoutExtension(file);
            lblTitle.Tag = Path.GetFileNameWithoutExtension(file);
            */

            log("Output File location: " + file, null, true);
            string ffmpeg_location = txtFFMPEG.Text + "ffmpeg.exe";
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            string fname_noext = Path.GetFileNameWithoutExtension(file);
            string fname_root = Path.GetDirectoryName(file);

            string filename = file;

            TimeSpan length = GetDuration(file);

            log("Total Length: " + length.ToString());

            double secs = length.TotalSeconds;
            if (secs == 0)
            {
                log("Couldn't get file length", "Conversion Error");
                return;
            }
            double tosecs = (double)numMin.Value * 60;

            double maxFiles = Math.Ceiling(secs / tosecs);

            TimeSpan outTime = TimeSpan.FromSeconds(tosecs);

            log("Compiling " + Math.Ceiling(secs / tosecs).ToString() + " file(s)");

            progressBar1.Maximum = (int)(maxFiles - 1);
            progressBar1.Value = 0;
            string finalFileName = "";
            for (int i = 0; i < maxFiles; i++)
            {
                if (currStep == 0)
                {
                    log("User request stoppage.");
                    proc.Kill();
                    return;
                }
                progressBar2.Value = 0;
                progressBar2.Maximum = (int)tosecs;
                string num = "00";

                num = (i + 1).ToString().PadLeft(maxFiles.ToString().Length, '0');

                string fname = Path.GetFileNameWithoutExtension(file);

                finalFileName = (chkAuthor.Checked == true ? txtAuthor.Text + " - " : "") + txtTitle.Text + (chkChapters.Checked == true ? " - Chapter " + num : "") +".mp3";

                if (File.Exists(txtSavePath.Text + finalFileName)==true)
                {
                    log("Deleting existing file.");
                    File.Delete(txtSavePath.Text + finalFileName);
                }
                string filters = txtFilters.Text;
                if (cmbSpeed.SelectedIndex != 5) filters += (filters!="" ? "," : "") + "atempo = " + cmbSpeed.Text;

                log(filters, null, true);

                string cmd = "-i \"" + file + "\" -ss " + TimeSpan.FromSeconds(outTime.TotalSeconds * i).ToString() + " -t " + outTime.ToString() + " -b:a " + numBitrate.Value.ToString() + "k" + (filters != "" ? " -filter:a \"" + filters + "\"" : "") + " -map a \"" + txtSavePath.Text + finalFileName + "\"";
                log("Command: " + cmd);

                proc.StartInfo.Arguments = cmd;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                if (!proc.Start())
                {
                    Console.WriteLine("Error starting");
                }
                StreamReader reader = proc.StandardError;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (currStep == 0)
                    {
                        log("User request stoppage.");
                        if(proc.HasExited== false) proc.Kill();
                        return;
                    }
                    TimeSpan ts = new TimeSpan();

                    string dur = str_get_between(line, "Duration: ", ",", 0);
                    if (dur != null)
                    {
                        TimeSpan.TryParse(dur, out ts);
                        if (ts.TotalSeconds < tosecs) progressBar2.Maximum = (int)ts.TotalSeconds;
                        if (ts.TotalSeconds == 0)
                        {
                            log("Seeking to correct position...");
                        }
                        else
                        {
                            log("Position in file: " + dur);
                        }
                    }
                    Application.DoEvents();
                    string kk = str_get_between(line, " time=", " ", 0);
                    if (kk != null)
                    {
                        TimeSpan.TryParse(kk, out ts);
                        progressBar2.Value = ((int)ts.TotalSeconds<=progressBar2.Maximum ? (int)ts.TotalSeconds : progressBar2.Maximum);
                        if (ts.TotalSeconds == 0)
                        {
                            log("Seeking to correct position...");
                        }
                        else
                        {
                            log("Position in file: " + kk);
                        }
                    }
                    log(line, null, true);
                }



                //finished converting
                log("Adding ID3 Tags...");
                TagLib.File tagFile = TagLib.File.Create(txtSavePath.Text + finalFileName);
                tagFile.Tag.Title = txtTitle.Text + (chkChapters.Checked == true ? " - Chapter " + num : "");
                tagFile.Tag.Track = (uint)Int32.Parse(num);

                if (txtAuthor.Text != "")
                {
                    tagFile.Tag.Conductor = txtAuthor.Text;
                    tagFile.Tag.AlbumArtists = new string[] { txtAuthor.Text };
                    tagFile.Tag.Performers = new string[] { txtAuthor.Text };
                }
                tagFile.Tag.Album = txtTitle.Text;
                tagFile.Tag.Comment = "Youtube to Audio";
                tagFile.Tag.Genres = new string[] { "Audiobook", "Podcast" };

                log(txtSavePath.Text + txtTitle.Tag + ".jpg");

                if (txtTitle.Tag != null)
                {
                    log("Image Exists: " + File.Exists(txtTitle.Tag.ToString()));
                    if (File.Exists(txtTitle.Tag.ToString()) == true)
                    {
                        TagLib.IPicture[] pictures = new TagLib.IPicture[1];
                        pictures[0] = new TagLib.Picture(txtTitle.Tag.ToString());
                        //pictures[0] = new TagLib.Picture(txtSavePath.Text + "Howard_Stern_Channel_9_Show_Episode_27_1991_.jpg");
                        tagFile.Tag.Pictures = pictures;
                    }
                }

                tagFile.Save();
                log("ID3 tags added.");
                proc.Close();


                progressBar1.Value = i;
                log("Chapter " + (i + 1).ToString() + " of " + maxFiles.ToString() + " completed.");
            }

            progressBar2.Value = progressBar2.Maximum;
            progressBar1.Value = progressBar1.Maximum;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtDebug_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log("Hi! I'm the log. Watch me for boring stuff :)");

            string pa = ini.IniReadValue("options", "save_path");
            string ff = ini.IniReadValue("options", "ffmpeg");

            string mins = ini.IniReadValue("options", "minutes");
            string kbps = ini.IniReadValue("options", "bitrate");


            if (pa != "") txtSavePath.Text = pa;
            if (ff != "") txtFFMPEG.Text = ff;

            int n;
            if (int.TryParse(mins, out n))
            {
                n = Int32.Parse(mins);
                if (n >= 0 && n <= 900) numMin.Value = n;
            }
            if (int.TryParse(kbps, out n))
            {
                n = Int32.Parse(kbps);
                if (n >= 8 && n <= 256) numBitrate.Value = n;
            }

            string tmp = ini.IniReadValue("options", "add_author");
            chkAuthor.Checked = (tmp == "" || tmp == "false" ? false : true);
            tmp = ini.IniReadValue("options", "log");
            chkLog.Checked = (tmp == "" || tmp == "false" ? false : true);
            tmp = ini.IniReadValue("options", "add_chapters");
            chkChapters.Checked = (tmp == "" || tmp == "false" ? false : true);
            tmp = ini.IniReadValue("options", "volume_fix");
            chkVolume.Checked = (tmp == "" || tmp == "false" ? false : true);
            tmp = ini.IniReadValue("options", "use_fetcher");
            chkService.Checked = (tmp == "" || tmp == "false" ? false : true);
            tmp = ini.IniReadValue("options", "rnd_fetcher");
            chkRandom.Checked = (tmp == "" || tmp == "false" ? false : true);

            log("Options Path: " + ini.path, null, true);

            for(int i=5;i<21;i++)
            {
                string spd = i.ToString();
                if (spd.Length == 1)
                {
                    spd = "0." + spd;
                }
                else
                {
                    spd = spd.Substring(0,1) + "." + spd.Substring(1,1);
                }
                cmbSpeed.Items.Add(spd);
            }
            cmbSpeed.SelectedIndex = 5;


            DirectoryInfo di = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\fetchers\\");
            FileInfo[] files = di.GetFiles("*.fetch");

            tmp = ini.IniReadValue("options", "fetcher");
            int selectedFetcher = 0;
            foreach (FileInfo file in files)
            {
                cmbFetchers.Items.Add(Path.GetFileNameWithoutExtension(file.Name.ToString()));
                if(tmp == Path.GetFileNameWithoutExtension(file.Name.ToString()))
                {
                    selectedFetcher = cmbFetchers.Items.Count - 1;
                }
            }
            if (cmbFetchers.Items.Count > 0)
            {
                cmbFetchers.SelectedIndex = selectedFetcher;
            }
            else
            {
                chkService.Enabled = false;
            }
        }


        private void btnFFmpeg_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.SelectedPath = txtFFMPEG.Text;
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK) return;

            txtFFMPEG.Text = folderBrowserDialog1.SelectedPath + "\\";
            log("FFMPEG Path: " + txtFFMPEG.Text, null, true);

            if(File.Exists(txtFFMPEG.Text + "ffmpeg.exe")==false)
            {
                log("Could not find FFMEG in provided path.");
            }

            ini.IniWriteValue("options", "ffmpeg", txtFFMPEG.Text);


        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtSavePath.Text;
            if (folderBrowserDialog1.ShowDialog(this) != DialogResult.OK) return;

            txtSavePath.Text = folderBrowserDialog1.SelectedPath + "\\";
            log("FFMPEG Path: " + txtSavePath.Text + "\\", null, true);

            if (File.Exists(txtSavePath.Text + "ffmpeg.exe") == false)
            {
                log("Could not find FFMEG in provided path.");
            }

            ini.IniWriteValue("options", "save_path", txtSavePath.Text);
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("options", "minutes", numMin.Value.ToString());
        }

        private void numBitrate_ValueChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("options", "bitrate", numBitrate.Value.ToString());
        }

        private void chkLog_CheckedChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("options", "log", chkLog.Checked.ToString().ToLower());
        }

        private void txtURL_MouseUp(object sender, MouseEventArgs e)
        {
            txtURL.SelectAll();
        }

        private void btnLocalLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "MP4 Video (*.mp4)|*.mp4|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            txtURL.Text = openFileDialog1.FileName;
            txtTitle.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
        }

        private void picThumb_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG Image Files (*.jpg)|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            picThumb.Load(openFileDialog1.FileName);
            txtTitle.Tag = openFileDialog1.FileName;
        }

        public void detectVolume()
        {
            log("Detecting volume. This could take awhile...");
            string file = null;
            if (ytinfo_vid != null)
            {
                file = txtSavePath.Text + ytinfo_vid[1] + ".mp4";
            }
            else
            {
                if (File.Exists(txtURL.Text) == true)
                {
                    file = txtURL.Text;
                }
            }

            if (file == null)
            {
                log("No file found to detect audio.", "File Error");
                return;
            }

            DateTime lastReported = DateTime.Now;

            string ffmpeg_location = txtFFMPEG.Text + "ffmpeg.exe";
            Process proc = new Process();
            proc.StartInfo.FileName = ffmpeg_location;

            proc.StartInfo.Arguments = "-i " + "\"" + file + "\" -af volumedetect  -f null -";
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            if (!proc.Start())
            {
                Console.WriteLine("Error starting");
            }
            StreamReader reader = proc.StandardError;
            string line;
            TimeSpan tsDur = new TimeSpan();

            while ((line = reader.ReadLine()) != null)
            {
                log(line, null, true);


                string dur = str_get_between(line, "Duration: ", ",", 0);
                if (dur != null)
                {
                    TimeSpan.TryParse(dur, out tsDur);
                }

                string kk = str_get_between(line, " time=", " ", 0);
                if (kk != null)
                {
                    TimeSpan ts = new TimeSpan();
                    TimeSpan.TryParse(kk, out ts);

                    log("Volume Detect Progress: " + Math.Floor(ts.TotalSeconds / tsDur.TotalSeconds * 100).ToString() + "%");
                }


                int a = line.IndexOf("max_volume: ");
                if (a >= 0)
                {
                    int b = line.IndexOf("dB", a + 1);
                    string num = line.Substring(a + 12, b - a - 13);
                    double max_volume = Double.Parse(num, System.Globalization.NumberStyles.Any);

                    log("Maxfile found: " + num);
                    if (max_volume < 0)
                    {

                        txtFilters.AppendText((txtFilters.Text == "" ? "" : ",") + "volume=" + Math.Abs(max_volume) + "dB");
                    }
                    break;
                }

                /*
                if(DateTime.Now.Ticks - lastReported.Ticks > 10000000)
                {
                    lastReported = DateTime.Now;
                    log("Still checking volume...");
                }
                */

                Application.DoEvents();
            }
            proc.Close();

        }

        public string fetchUrl(string service)
        {
            /* Fetcher Format

            [POST,GET][tab][WEBSITE]                        //METHOD to request website url
            [DATA][tab][NAME][tab][VALUE]                   //if post is used, you can send uploaded values
            [BETWEEN][tab][[@@@>]START STRING][tab][[@@@>]END STRING]   //get the string between start and end string (can be called multiple times to drill down to a final result) optional '-->' forces the value onto the start or end of string
            [DECODE]                                        //unescapes % values from final result. (can be called multiple times)


            */

            try
            {
                Uri uri = null;
                if (!Uri.TryCreate(txtURL.Text, UriKind.Absolute, out uri))
                {
                    try
                    {
                        uri = new UriBuilder("http", txtURL.Text).Uri;
                    }
                    catch
                    {
                        log("Please provide a valid Youtube URL.", "Youtube Error");
                        return null;
                    }
                }


                string furl = null;

                string get_url = null;
                string post_url = null;

                string[][] splits = new string[10][];

                int decode = 0, splitCnt = 0;

                var data = new NameValueCollection();

                var lines = File.ReadLines(AppDomain.CurrentDomain.BaseDirectory + "\\fetchers\\" + service + ".fetch");
                
                foreach (var line in lines)
                {
                    string nline = line.Replace("%YT_URL%", txtURL.Text).Replace("%YT_ID%", ExtractVideoIdFromUri(uri));
                    log(nline, null, true);
                    string[] tabbed = nline.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    if (tabbed[0] == "GET")
                    {
                        get_url = tabbed[1];
                        log("GET URL: " + tabbed[1], null, true);
                    }
                    else if (tabbed[0] == "POST")
                    {
                        post_url = tabbed[1];
                        log("POST URL: " + tabbed[1], null, true);
                    }
                    else if (tabbed[0] == "BETWEEN")
                    {
                        splits[splitCnt] = new string[2];
                        splits[splitCnt][0] = tabbed[1];
                        splits[splitCnt][1] = tabbed[2];
                        splitCnt++;
                    }
                    else if (tabbed[0] == "DATA")
                    {
                        data[tabbed[1]] = tabbed[2];
                    }
                    else if (tabbed[0] == "DECODE")
                    {
                        decode++;
                    }

                }

                using (var wb = new WebClient())
                {
                    byte[] response = null;

                    if (post_url != null)
                    {
                        response = wb.UploadValues(post_url, "POST", data);
                    }
                    else if (get_url != null)
                    {
                        response = Encoding.ASCII.GetBytes(wb.DownloadString(get_url));
                    }
                    else
                    {
                        log("Failed to fetch URL!");
                        return null;
                    }



                    string responseInString = Encoding.UTF8.GetString(response);
                    log("Response: " + responseInString, null, true);
                    for (int i = 0; i < splitCnt; i++)
                    {
                        string a="", b="";
                        if (splits[i][0].StartsWith("@@@>"))
                        {
                            splits[i][0] = splits[i][0].Substring(4);
                            a = splits[i][0];
                        }

                        if (splits[i][1].StartsWith("@@@>"))
                        {
                            splits[i][1] = splits[i][1].Substring(4);
                            b = splits[i][1];
                        }

                        furl = a + str_get_between(responseInString, splits[i][0], splits[i][1], 0) + b;
                    }
                    if (furl == null)
                    {
                        log("Failed to fetch URL!");
                        return null;
                    }

                    for(int i=0;i<decode;i++)
                    {
                        furl = str_unescape(furl);
                    }

                    log("Fetched URL: " + furl);
                }
                return furl;
            }
            catch (Exception ex)
            {
                log(ex.ToString(), "Fetcher Error");
                return null;
            }

        }

        private void btnVolumeDetect_Click(object sender, EventArgs e)
        {

            
        }

        private void chkService_CheckedChanged(object sender, EventArgs e)
        {
            cmbFetchers.Enabled = chkService.Checked;
            ini.IniWriteValue("options", "use_fetcher", chkService.Checked.ToString().ToLower());
        }

        private void chkVolume_CheckedChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("options", "volume_fix", chkVolume.Checked.ToString().ToLower());
        }

        private void chkChapters_CheckedChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("options", "add_chapters", chkChapters.Checked.ToString().ToLower());
        }

        private void chkAuthor_CheckedChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("options", "add_author", chkAuthor.Checked.ToString().ToLower());
        }

        private void cmbFetchers_SelectedIndexChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("options", "fetcher", cmbFetchers.Text);
        }

        private void btnAddQueue_Click(object sender, EventArgs e)
        {
            lstQueue.Items.Add(txtURL.Text);
            txtURL.Text = "";
        }

        private void chkRandom_CheckedChanged(object sender, EventArgs e)
        {
            ini.IniWriteValue("options", "rnd_fetcher", chkRandom.Checked.ToString().ToLower());
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
