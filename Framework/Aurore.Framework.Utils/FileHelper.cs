/*----------------------------------------------------------------
    Copyright (C) 2016 Aurore
    
    文件名：FileHelper.cs
    文件功能描述：根据完整文件路径获取FileStream
    
    
    创建标识：Aurore - 20150211
    
    修改标识：Aurore - 20150303
    修改描述：整理接口
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Aurore.Framework.Utils
{
    public class FileHelper
    {
        /// <summary>
        /// 根据完整文件路径获取FileStream
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FileStream GetFileStream(string fileName)
        {
            FileStream fileStream = null;
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName))
            {
                fileStream = new FileStream(fileName, FileMode.Open);
            }
            return fileStream;
        }

        /// <summary>
        /// 复制大文件
        /// </summary>
        /// <param name="fromPath">源文件的路径</param>
        /// <param name="toPath">文件保存的路径</param>
        /// <param name="eachReadLength">每次读取的长度</param>
        /// <returns>是否复制成功</returns>
        public static bool CopyFile(string fromPath, string toPath, int eachReadLength)
        {
            //将源文件 读取成文件流
            FileStream fromFile = new FileStream(fromPath, FileMode.Open, FileAccess.Read);
            //已追加的方式 写入文件流
            FileStream toFile = new FileStream(toPath, FileMode.Append, FileAccess.Write);
            //实际读取的文件长度
            int toCopyLength = 0;
            //如果每次读取的长度小于 源文件的长度 分段读取
            if (eachReadLength < fromFile.Length)
            {
                byte[] buffer = new byte[eachReadLength];
                long copied = 0;
                while (copied <= fromFile.Length - eachReadLength)
                {
                    toCopyLength = fromFile.Read(buffer, 0, eachReadLength);
                    fromFile.Flush();
                    toFile.Write(buffer, 0, eachReadLength);
                    toFile.Flush();
                    //流的当前位置
                    toFile.Position = fromFile.Position;
                    copied += toCopyLength;

                }
                int left = (int)(fromFile.Length - copied);
                toCopyLength = fromFile.Read(buffer, 0, left);
                fromFile.Flush();
                toFile.Write(buffer, 0, left);
                toFile.Flush();

            }
            else
            {
                //如果每次拷贝的文件长度大于源文件的长度 则将实际文件长度直接拷贝
                byte[] buffer = new byte[fromFile.Length];
                fromFile.Read(buffer, 0, buffer.Length);
                fromFile.Flush();
                toFile.Write(buffer, 0, buffer.Length);
                toFile.Flush();

            }
            fromFile.Close();
            toFile.Close();
            return true;
        }

        /// <summary>
        /// 获取文件路径中最后的目录名
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDirectoryName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return null;
            }
            return fullName.Substring(0, fullName.LastIndexOf('\\') + 1);
        }
        /// <summary>
        /// 获取路径中的文件名称
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileName(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return string.Empty;
            }
            if (filePath.Length > 260)
            {
                return filePath.Substring(filePath.LastIndexOf('\\') + 1, int.MaxValue);
            }
            return Path.GetFileName(filePath);
        }
        /// <summary>
        /// 文件名是否满足filePattern格式。
        /// </summary>
        /// <param name="fileName"></param>
        public static bool IsMatched(string fileName, string filePattern)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(filePattern))
            {
                return false;
            }
            Regex regex = new Regex(filePattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(fileName);
        }
        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string ReadAllText(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || File.Exists(filePath) == false)
            {
                return string.Empty;
            }
            return File.ReadAllText(filePath);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="filePath"></param>
        public static bool Delete(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return false;
            }
            if (!File.Exists(filePath))
            {
                return false;
            }
            File.Delete(filePath);
            return !File.Exists(filePath);
        }
        /// <summary>
        /// 删除目录下所有过期文件
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="expiredDays"></param>
        public static int ClearExpiredFiles(string directory, int expiredDays)
        {
            if (!Directory.Exists(directory))
            {
                return 0;
            }
            if (expiredDays <= 0)
            {
                return 0;
            }
            DirectoryInfo dir = new DirectoryInfo(directory);
            IList<FileInfo> fileInfos = dir.GetFiles();
            if (fileInfos == null || fileInfos.Count < 1)
            {
                return 0;
            }
            int count = 0;
            foreach (FileInfo fileInfo in fileInfos)
            {
                if (fileInfo.CreationTime.AddDays(expiredDays) < DateTime.Now)
                {
                    //added by yangbinggang
                    fileInfo.Attributes = FileAttributes.Normal;
                    FileHelper.Delete(fileInfo.FullName);
                    count = count + 1;
                }
            }
            return count;
        }
        /// <summary>
        /// 删除目录下所有过期文件
        /// </summary>
        /// <param name="dirs">目录数组</param>
        /// <param name="expiredDays"></param>
        /// <returns></returns>
        public static int ClearExpiredFiles(string[] dirs, int expiredDays)
        {
            if (dirs == null)
            {
                return 0;
            }
            if (dirs.Length <= 0)
            {
                return 0;
            }
            int count = 0;
            foreach (string dir in dirs)
            {
                count = count + ClearExpiredFiles(dir, expiredDays);
            }
            return count;
        }
        /// <summary>
        /// 删除过期目录及其子目录和文件
        /// </summary>
        /// <param name="directories">目录数组</param>
        /// <param name="expiredDays"></param>
        /// <returns></returns>
        public static int ClearExpiredDirectories(string[] directories, int expiredDays)
        {
            if (directories == null || directories.Length <= 0)
            {
                return 0;
            }
            if (expiredDays < 0)
            {
                return 0;
            }
            int count = 0;
            foreach (string directory in directories)
            {
                if (!Directory.Exists(directory))
                {
                    continue;
                }
                count += ClearExpiredFiles(directory, expiredDays);
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                if (directoryInfo.CreationTime.AddDays(expiredDays) < DateTime.Now)
                {
                    directoryInfo.Attributes = FileAttributes.Normal;
                    Directory.Delete(directory, true);
                }
            }
            return count;
        }
        /// <summary>
        /// 深度枚举出所有子目录（包括子目录的子目录）
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static IList<string> EnumerateAllSubDirectories(string directory)
        {
            List<string> direcotryList = new List<string>();
            if (string.IsNullOrWhiteSpace(directory))
            {
                return direcotryList;
            }
            if (!Directory.Exists(directory))
            {
                return direcotryList;
            }
            string[] folders = Directory.GetDirectories(directory);
            direcotryList.AddRange(folders);
            foreach (string folder in folders)
            {
                direcotryList.AddRange(EnumerateAllSubDirectories(folder));
            }
            return direcotryList;
        }
        /// <summary>
        /// 根据时间查询文件
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="maxCount"></param>
        /// <returns></returns>
        public static IList<string> FindFiles(string directory, int maxCount, int days)
        {
            IList<string> fileList = new List<string>();
            if (!Directory.Exists(directory) || maxCount <= 0)
            {
                return fileList;
            }
            string[] files = Directory.GetFiles(directory);
            if (files == null)
            {
                return fileList;
            }
            //modified by yangbinggang 2012-12-10  DTS2012121004132\DTS2012121004404\DTS2012121004291
            DateTime lastTime = DateTime.Now.AddDays(-Math.Abs(days));
            fileList = files.Where(item =>
            {
                if (maxCount <= 0)
                {
                    return false;
                }
                FileInfo fileInfo = new FileInfo(item);
                if (fileInfo.LastWriteTime >= lastTime)
                {
                    maxCount--;
                    return true;
                }
                return false;
            }).ToList<string>();
            return fileList;
        }
        /// <summary>
        /// 查询目录下的所有文件，将recursive设为True可查询子目录中的所有文件。
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePattern"></param>
        /// <param name="maxCount"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public static IList<FileInfo> FindFiles(string directory, string filePattern, int maxCount, bool recursive)
        {
            if (!recursive)
            {
                return FileHelper.FindFiles(directory, filePattern, maxCount);
            }
            IList<string> directories = EnumerateAllSubDirectories(directory);
            return FindFiles(directories, filePattern, maxCount);
        }
        public static IList<FileInfo> FindFiles(IList<string> directories, string filePattern, int maxCount)
        {
            List<FileInfo> files = new List<FileInfo>();
            foreach (string directoryItem in directories)
            {
                files.AddRange(FileHelper.FindFiles(directoryItem, filePattern, maxCount));
                if (files.Count > maxCount)
                {
                    break;
                }
            }
            return files.GetRange(0, Math.Min(files.Count, maxCount));
        }
        /// <summary>
        /// 默认查找20个文件
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePattern"></param>
        /// <returns></returns>
        public static IList<FileInfo> FindFiles(string directory, string filePattern)
        {
            int maxCount = 20;
            return FindFiles(directory, filePattern, maxCount);
        }
        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="filePattern"></param>
        /// <returns></returns>
        public static IList<FileInfo> FindFiles(string directory, string filePattern, int maxCount)
        {
            List<FileInfo> matchedFiles = new List<FileInfo>();
            IList<FileInfo> fileInfos = FindAllFiles(directory);
            if (string.IsNullOrWhiteSpace(filePattern))
            {
                return matchedFiles;
            }
            if (maxCount < 0 || maxCount > fileInfos.Count)
            {
                maxCount = fileInfos.Count;
            }
            maxCount--;
            foreach (var fileInfo in fileInfos)
            {
                if (maxCount < 0)
                {
                    break;
                }
                if (FileHelper.IsMatched(fileInfo.Name, filePattern))
                {
                    matchedFiles.Add(fileInfo);
                }
                maxCount--;
            }
            return matchedFiles;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static IList<FileInfo> FindAllFiles(string directory)
        {
            IList<FileInfo> fileInfos = new List<FileInfo>();
            if (string.IsNullOrWhiteSpace(directory))
            {
                return fileInfos;
            }
            if (!Directory.Exists(directory))
            {
                return fileInfos;
            }
            DirectoryInfo dir = new DirectoryInfo(directory);
            fileInfos = dir.GetFiles();
            return fileInfos;
        }
        /// <summary>
        /// 单个文件移动
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetDirectory"></param>
        /// <returns></returns>
        public static bool MoveFile(string sourcePath, string targetDirectory)
        {
            if (!File.Exists(sourcePath))
            {
                return false;
            }
            if (!Directory.Exists(targetDirectory))
            {
                return false;
            }
            var targetPath = string.Format("{0}\\{1}", targetDirectory, FileHelper.GetFileName(sourcePath));
            while (File.Exists(targetPath))
            {
                targetPath = FileHelper.Rename(targetPath);
            }
            if (sourcePath.Length > 260 || targetPath.Length > 260)
            {
                return MoveLongPathFile(@"\\?\" + sourcePath, @"\\?\" + targetPath);
            }
            File.Move(sourcePath, targetPath);
            return true;
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true, EntryPoint = "MoveFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MoveLongPathFile(string lpExistingFileName, string lpNewFileName);
        /// <summary>
        /// 单个文件移动
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        /// <returns></returns>
        public static bool MoveFile(string fileName, string sourceDirectory, string targetDirectory)
        {
            //if (!File.Exists(fileName))
            //{
            //    return false;
            //}
            //if (!Directory.Exists(sourceDirectory))
            //{
            //    return false;
            //}
            //if (!Directory.Exists(targetDirectory))
            //{
            //    return false;
            //}
            string filePath = fileName.Replace(sourceDirectory, targetDirectory);
            string fileDir = Path.GetDirectoryName(filePath);
            //if (!Directory.CreateDirectory(fileDir))
            //{
            //    return false;
            //}
            return MoveFile(fileName, fileDir);
        }
        /// <summary>
        /// 重新生成新的文件路径
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string Rename(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return string.Empty;
            }
            string lastFileName = Path.GetFileNameWithoutExtension(filePath);
            string lastFileExtension = Path.GetExtension(filePath);
            //重命名，则随机在原来文件名后面加几个随机数字进行组装成新的名字
            Random random = new Random(System.DateTime.Now.Millisecond);
            string randomData = random.Next().ToString();
            //把原文件名的名字加上随机数，组装成新的文件名（避免重名）
            string newFileName = lastFileName + randomData;
            return Path.GetDirectoryName(filePath) + "\\" + newFileName + lastFileExtension;
        }

    }
}
