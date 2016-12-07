/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.filebrowserBrowseUrl = '/admin/image-manager';
	config.allowedContent = true;
	config.toolbar_References = [
		[ 'Source', 'Bold', 'Italic', 'NumberedList', 'Link', 'Unlink', 'Maximize' ]
	];
};
