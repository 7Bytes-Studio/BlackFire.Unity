/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

var input = 
{
	showPrompt: function(messagePtr, objectNamePtr, callbackFuncNamePtr)
	{
		var message = Pointer_stringify(messagePtr);
		var objectName = Pointer_stringify(objectNamePtr);
		var funcName = Pointer_stringify(callbackFuncNamePtr);

		var result = prompt(message, "");
		if (result != null)
			SendMessage(objectName, funcName, result);
	}
};

mergeInto(LibraryManager.library, input);