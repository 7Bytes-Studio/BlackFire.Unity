/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

var fileBrowser = 
{
	fileBrowserInit: function(objectNamePtr, callbackFuncNamePtr)
	{
		var objectName = Pointer_stringify(objectNamePtr);
		var funcName = Pointer_stringify(callbackFuncNamePtr);

		var fileuploader = document.getElementById('fileuploader');
		if (!fileuploader)
		{
			fileuploader = document.createElement('input');
			fileuploader.setAttribute('style','display:none;');
			fileuploader.setAttribute('type', 'file');
			fileuploader.setAttribute('accept', 'image/*');
			fileuploader.setAttribute('id', 'fileuploader');
			document.getElementsByTagName('body')[0].appendChild(fileuploader);

			fileuploader.onchange = function(e) 
			{
				var files = e.target.files;
				for (var i = 0, f; f = files[i]; i++) 
				{
					SendMessage(objectName, funcName, URL.createObjectURL(f));
				}
			};
		}
		document.addEventListener('click', function() 
		{
			var fileuploader = document.getElementById('fileuploader');
			if (fileuploader && fileuploader.getAttribute('class') == 'focused') 
			{
				fileuploader.setAttribute('class', '');
				fileuploader.click();
			}
		});
	},

	fileBrowserSetFocus: function()
	{
		var fileuploader = document.getElementById('fileuploader');
		if (fileuploader)
			fileuploader.setAttribute('class', 'focused');
	}
};

mergeInto(LibraryManager.library, fileBrowser);