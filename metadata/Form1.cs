using System.Text.Json;
using System.Text.RegularExpressions;

namespace metadata
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 主要搜尋功能
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            txtHint.Text = "";
            string url = tbxOsuLink.Text; // 從 tbxOsuLink 獲取輸入的網址
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageBox.Show("請輸入網址。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string title = await FetchOsuLinkAsync(url, "title");
                if (!string.IsNullOrEmpty(title))
                {
                    // 影片標題
                    tbxTitle.Text = $"{title} | osu!🧬 #shorts #music #gameplay";

                    // 顯示描述 Beatmap, Skin, Original song, Tags
                    string originalSongUrl = await FetchYouTubeUrlAsync(title);
                    string tags = await FetchOsuLinkAsync(url, "tags");
                    string hashtags = "";
                    if (tags != null)
                    {
                        string pattern = @"[^\w\s_]";
                        hashtags = Regex.Replace(tags, pattern, "");

                        string[] tagsList = hashtags.Split(" ");
                        hashtags = "#" + string.Join(" #", tagsList);
                    }
                    tbxDesc.Text = $"Beatmap: {url}\n" +
                                    $"Skin: https://drive.google.com/file/d/1Hg7TVmoHr9ADUKtWsH2nRbb_js0-MJZw/view\n\n" +
                                    "---\n\n" +
                                    $"Original song: {originalSongUrl}\n\n" +
                                    $"#osu  #vtuber #gaming #gameplay #viral #osugame #anime #short #shorts #reels #pop #music #kpop #jpop #rap \n" +
                                    $"{hashtags}";

                    // 顯示拼接後的標籤
                    if (tags != null)
                    {
                        string romanizedTags = GenerateTags(tags);
                        tbxTags.Text = romanizedTags;
                    }
                }
                else
                {
                    MessageBox.Show("無法提取標題，請檢查網址是否正確。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 回傳圖譜資訊
        private async Task<string> FetchOsuLinkAsync(string url, string param)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                Match match = Regex.Match(content, @"<script id=""json-beatmapset"" type=""application/json"">(.*?)</script>", RegexOptions.Singleline);
                if (match.Success)
                {

                    if (param == "title")
                    {
                        string jsonContent = match.Groups[1].Value;

                        using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                        {
                            string? artistUnicode = doc.RootElement.GetProperty("artist_unicode").GetString();
                            string? titleUnicode = doc.RootElement.GetProperty("title_unicode").GetString();

                            if (artistUnicode != null && titleUnicode != null)
                            {
                                artistUnicode = RemoveBannedWords(artistUnicode);
                                titleUnicode = RemoveBannedWords(titleUnicode);
                            }

                            return $"{artistUnicode} - {titleUnicode}";
                        }

                    }
                    else if (param == "tags")
                    {
                        string jsonContent = match.Groups[1].Value;

                        using (JsonDocument doc = JsonDocument.Parse(jsonContent))
                        {
                            if (doc.RootElement.TryGetProperty("tags", out JsonElement tagsElement))
                            {
                                string? artist = doc.RootElement.GetProperty("artist").GetString();
                                string? title = doc.RootElement.GetProperty("title").GetString();
                                string? tags = doc.RootElement.GetProperty("tags").GetString();

                                if (artist != null && title != null && tags != null)
                                {
                                    artist = RemoveBannedWords(artist);
                                    title = RemoveBannedWords(title);
                                    tags = RemoveBannedWords(tags);
                                }

                                return $"{artist} {title} {tags}";
                            }
                        }
                    }
                }
            }
            return "";
        }

        // 移除特定字串
        static string RemoveBannedWords(string input)
        {
            var banList = new List<string> {
                    "(TV Size)",
                    "(TV size)",
                    "(Cut Ver.)",
                    "(Cut ver.)",
                    "(Cut Version)",
                    "(Cut version)",
                    "(TV Edit.)",
                    "(TV edit.)",
                    "(TV Edit)",
                    "(TV edit)"
            };

            if (input == string.Empty) { return ""; }
            foreach (var bannedWord in banList)
            {
                input = Regex.Replace(input, Regex.Escape(bannedWord), "", RegexOptions.IgnoreCase).Trim();
            }

            return Regex.Replace(input, @"\s{2,}", " ");
        }

        // 搜尋 Youtube 原曲網址，回傳第一個搜尋結果
        private async Task<string> FetchYouTubeUrlAsync(string title)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                string searchQuery = Uri.EscapeDataString(title);
                string searchUrl = $"https://www.youtube.com/results?search_query={searchQuery}";

                HttpResponseMessage response = await client.GetAsync(searchUrl);
                response.EnsureSuccessStatusCode();

                string content = await response.Content.ReadAsStringAsync();

                Match match = Regex.Match(content, @"\/watch\?v=([\w\-]+)", RegexOptions.Singleline);
                if (match.Success)
                {
                    return $"https://www.youtube.com/watch?v={match.Groups[1].Value}";
                }
            }
            return "未找到影片";
        }

        // 整理標籤
        private string GenerateTags(string tags)
        {
            int maxLength = 500;
            string[] fixedTags = new[] { "osu", "osugame", "anime", "gaming", "kpop", "jpop", "pop", "music", "vtuber", "short", "reel", "viral", "aim" };
            string combinedTags = string.Join(",", fixedTags) + "," + tags.Replace(" ", ",") + ",";
            
            if (combinedTags.Length > maxLength)
            {
                combinedTags = combinedTags.Substring(0, maxLength);

                // 確保不截斷單詞，往前找最後一個逗號的位置
                int lastCommaIndex = combinedTags.LastIndexOf(", ");
                if (lastCommaIndex > 0)
                {
                    combinedTags = combinedTags.Substring(0, lastCommaIndex);
                }
            }
            return combinedTags;
        }

        // 清空所有 Textbox
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定重置嗎?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                tbxOsuLink.Text = "";
                tbxTitle.Text = "";
                tbxDesc.Text = "";
                tbxTags.Text = "";

                txtHint.Text = "";
            }
            else
            {

            }
        }

        // 複製標題
        private void btnTitleCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbxTitle.Text);
            txtHint.Text = "已複製Title!";
        }

        // 複製描述
        private void btnDescCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbxDesc.Text);
            txtHint.Text = "已複製Desc!";
        }

        // 複製標籤
        private void btnTagsCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbxTags.Text);
            txtHint.Text = "已複製Tags!";
        }
    }
}
