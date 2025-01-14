﻿using Columbus.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Columbus.Domain
{
    internal class IOHandler
    {
        private readonly IDirectoryWrapper _directoryWrapper;
        private readonly IFileWrapper _fileWrapper;
        private readonly IPathWrapper _pathWrapper;

        public IOHandler(IDirectoryWrapper directoryWrapper, IFileWrapper fileWrapper, IPathWrapper pathWrapper)
        {
            this._directoryWrapper = directoryWrapper;
            this._fileWrapper = fileWrapper;
            this._pathWrapper = pathWrapper;
        }

        public async IAsyncEnumerable<string> EnumerateFilesByNameAsync(string folderPath, string searchPattern, SearchOption searchOption, bool unique, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var uniqueFileNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            await Task.Yield();

            var enumerable = new FileSystemEnumerable(new DirectoryInfo(folderPath), searchPattern, searchOption);

            foreach (var file in enumerable)
            {
                cancellationToken.ThrowIfCancellationRequested();

                string fileName;

                try
                {
                    fileName = _pathWrapper.GetFileName(file.Name);
                    string lowerCaseFileName = fileName.ToLower();

                    if (unique && !uniqueFileNames.Add(lowerCaseFileName))
                    {
                        continue;
                    }

                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }

                yield return file.FullName;
            }
        }
    }
}
