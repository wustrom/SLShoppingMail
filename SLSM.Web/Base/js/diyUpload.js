/* 
 *	jQuery鏂囦欢涓婁紶鎻掍欢,灏佽UI,涓婁紶澶勭悊鎿嶄綔閲囩敤Baidu WebUploader;
 *	@Author 榛戠埅鐖�;
 */
(function( $ ) {

    $.fn.extend({
        /*
         *	涓婁紶鏂规硶 opt涓哄弬鏁伴厤缃�;
         *	serverCallBack鍥炶皟鍑芥暟 姣忎釜鏂囦欢涓婁紶鑷虫湇鍔＄鍚�,鏈嶅姟绔繑鍥炲弬鏁�,鏃犺鎴愬姛澶辫触閮戒細璋冪敤 鍙傛暟涓烘湇鍔″櫒杩斿洖淇℃伅;
         */
        diyUpload:function( opt, serverCallBack ) {
            if ( typeof opt != "object" ) {
                alert('鍙傛暟閿欒!');
                return;
            }

            var $fileInput = $(this);
            var $fileInputId = $fileInput.attr('id');

            //缁勮鍙傛暟;
            if( opt.url ) {
                opt.server = opt.url;
                delete opt.url;
            }

            if( opt.success ) {
                var successCallBack = opt.success;
                delete opt.success;
            }

            if( opt.error ) {
                var errorCallBack = opt.error;
                delete opt.error;
            }

            //杩唬鍑洪粯璁ら厤缃�
            $.each( getOption( '#'+$fileInputId ),function( key, value ){
                opt[ key ] = opt[ key ] || value;
            });

            if ( opt.buttonText ) {
                opt['pick']['label'] = opt.buttonText;
                delete opt.buttonText;
            }

            var webUploader = getUploader( opt );

            if ( !WebUploader.Uploader.support() ) {
                alert( ' 涓婁紶缁勪欢涓嶆敮鎸佹偍鐨勬祻瑙堝櫒锛�');
                return false;
            }

            //缁戝畾鏂囦欢鍔犲叆闃熷垪浜嬩欢;
            webUploader.on('fileQueued', function( file ) {
                createBox( $fileInput, file ,webUploader);

            });

            //杩涘害鏉′簨浠�
            webUploader.on('uploadProgress',function( file, percentage  ){
                var $fileBox = $('#fileBox_'+file.id);
                var $diyBar = $fileBox.find('.diyBar');
                $diyBar.show();
                percentage = percentage*100;
                showDiyProgress( percentage.toFixed(2), $diyBar);

            });

            //鍏ㄩ儴涓婁紶缁撴潫鍚庤Е鍙�;
            webUploader.on('uploadFinished', function(){
                $fileInput.next('.parentFileBox').children('.diyButton').remove();
            });
            //缁戝畾鍙戦€佽嚦鏈嶅姟绔繑鍥炲悗瑙﹀彂浜嬩欢;
            webUploader.on('uploadAccept', function( object ,data ){
                if ( serverCallBack ) serverCallBack( data );
            });

            //涓婁紶鎴愬姛鍚庤Е鍙戜簨浠�;
            webUploader.on('uploadSuccess',function( file, response ){
                var $fileBox = $('#fileBox_'+file.id);
                var $diyBar = $fileBox.find('.diyBar');
                $fileBox.removeClass('diyUploadHover');
                $diyBar.fadeOut( 1000 ,function(){
                    $fileBox.children('.diySuccess').show();
                });
                if ( successCallBack ) {
                    successCallBack( response );
                }
            });

            //涓婁紶澶辫触鍚庤Е鍙戜簨浠�;
            webUploader.on('uploadError',function( file, reason ){
                var $fileBox = $('#fileBox_'+file.id);
                var $diyBar = $fileBox.find('.diyBar');
                showDiyProgress( 0, $diyBar , '涓婁紶澶辫触!' );
                var err = '涓婁紶澶辫触! 鏂囦欢:'+file.name+' 閿欒鐮�:'+reason;
                if ( errorCallBack ) {
                    errorCallBack( err );
                }
            });

            //閫夋嫨鏂囦欢閿欒瑙﹀彂浜嬩欢;
            webUploader.on('error', function( code ) {
                
            });
             return webUploader;
        }
    });

    //Web Uploader榛樿閰嶇疆;
    function getOption(objId) {
        /*
         *	閰嶇疆鏂囦欢鍚寃ebUploader涓€鑷�,杩欓噷鍙粰鍑洪粯璁ら厤缃�.
         *	鍏蜂綋鍙傜収:http://fex.baidu.com/webuploader/doc/index.html
         */
        return {
            //鎸夐挳瀹瑰櫒;
            pick:{
                id:objId,
                label:""
            },
            //绫诲瀷闄愬埗;
            accept:{
                title:"Images",
                extensions:"gif,jpg,jpeg,bmp,png",
                mimeTypes:"image/*"
            },
            //閰嶇疆鐢熸垚缂╃暐鍥剧殑閫夐」
            thumb:{
                width:160,
                height:120,
                // 鍥剧墖璐ㄩ噺锛屽彧鏈塼ype涓篳image/jpeg`鐨勬椂鍊欐墠鏈夋晥銆�
                quality:90,
                // 鏄惁鍏佽鏀惧ぇ锛屽鏋滄兂瑕佺敓鎴愬皬鍥剧殑鏃跺€欎笉澶辩湡锛屾閫夐」搴旇璁剧疆涓篺alse.
                allowMagnify:false,
                // 鏄惁鍏佽瑁佸壀銆�
                crop:true,
                // 涓虹┖鐨勮瘽鍒欎繚鐣欏師鏈夊浘鐗囨牸寮忋€�
                // 鍚﹀垯寮哄埗杞崲鎴愭寚瀹氱殑绫诲瀷銆�
                type:"image/jpeg"
            },
            //鏂囦欢涓婁紶鏂瑰紡
            method:"POST",
            //鏈嶅姟鍣ㄥ湴鍧€;
            server:"",
            //鏄惁宸蹭簩杩涘埗鐨勬祦鐨勬柟寮忓彂閫佹枃浠讹紝杩欐牱鏁翠釜涓婁紶鍐呭php://input閮戒负鏂囦欢鍐呭
            sendAsBinary:false,
            // 寮€璧峰垎鐗囦笂浼犮€� thinkphp鐨勪笂浼犵被娴嬭瘯鍒嗙墖鏃犳晥,鍥剧墖涓㈠け;
            chunked:true,
            // 鍒嗙墖澶у皬
            chunkSize:512 * 1024,
            //鏈€澶т笂浼犵殑鏂囦欢鏁伴噺, 鎬绘枃浠跺ぇ灏�,鍗曚釜鏂囦欢澶у皬(鍗曚綅瀛楄妭);
            fileNumLimit:50,
            fileSizeLimit:500000 * 1024,
            fileSingleSizeLimit:50000 * 1024,
        };
    }

    //瀹炰緥鍖朩eb Uploader
    function getUploader( opt ) {

        return new WebUploader.Uploader( opt );
    }

    //鎿嶄綔杩涘害鏉�;
    function showDiyProgress( progress, $diyBar, text ) {
        if ( progress >= 100 ) {
            progress = progress + '%';
            text = text || '涓婁紶瀹屾垚';
        } else {
            progress = progress + '%';
            text = text || progress;
        }

        var $diyProgress = $diyBar.find('.diyProgress');
        $diyProgress.width( progress ).text( text );

    }

    //鍙栨秷浜嬩欢;
    function removeLi ( $li ,file_id ,webUploader) {
        webUploader.removeFile( file_id );
        $li.remove();
    }

    //宸︾Щ浜嬩欢;
    function leftLi ($leftli, $li) {
        $li.insertBefore($leftli);
    }

    //鍙崇Щ浜嬩欢;
    function rightLi ($rightli, $li) {
        $li.insertAfter($rightli);
    }

    //鍒涘缓鏂囦欢鎿嶄綔div;
    function createBox( $fileInput, file, webUploader ) {
        var file_id = file.id;
        var $parentFileBox = $fileInput.parents(".upload-ul");
        var file_len=$parentFileBox.children(".diyUploadHover").length;

        //娣诲姞瀛愬鍣�;
        var li = '<li id="fileBox_'+file_id+'" class="diyUploadHover"> \
					<div class="viewThumb">\
					    <input type="hidden">\
					    <div class="diyBar"> \
							<div class="diyProgress">0%</div> \
					    </div> \
					    <p class="diyControl"><span class="diyLeft"><i></i></span><span class="diyCancel"><i></i></span><span class="diyRight"><i></i></span></p>\
					</div> \
				</li>';

        $parentFileBox.prepend( li );

        var $fileBox = $parentFileBox.find('#fileBox_'+file_id);

        //缁戝畾鍙栨秷浜嬩欢;
        var $diyCancel = $fileBox.find('.diyCancel').one('click',function(){
            removeLi( $(this).parents('.diyUploadHover'), file_id, webUploader );
        });

        //缁戝畾宸︾Щ浜嬩欢;
        $fileBox.find('.diyLeft').one('click',function(){
            leftLi($(this).parents('.diyUploadHover').prev(), $(this).parents('.diyUploadHover'));
        });

        //缁戝畾鍙崇Щ浜嬩欢;
        $fileBox.find('.diyRight').one('click',function(){
            rightLi($(this).parents('.diyUploadHover').next(), $(this).parents('.diyUploadHover') );
        });

        if ( file.type.split("/")[0] != 'image' ) {
            var liClassName = getFileTypeClassName( file.name.split(".").pop() );
            $fileBox.addClass(liClassName);
            return;
        }

        //鐢熸垚棰勮缂╃暐鍥�;
        webUploader.makeThumb( file, function( error, dataSrc ) {
            if ( !error ) {
                $fileBox.find('.viewThumb').append('<img src="'+dataSrc+'" >');
            }
        });
    }

    //鑾峰彇鏂囦欢绫诲瀷;
    function getFileTypeClassName ( type ) {
        var fileType = {};
        var suffix = '_diy_bg';
        fileType['pdf'] = 'pdf';
        fileType['ppt'] = 'ppt';
        fileType['doc'] = 'doc';
        fileType['docx'] = 'doc';
        fileType['jpg'] = 'jpg';
        fileType['zip'] = 'zip';
        fileType['rar'] = 'rar';
        fileType['xls'] = 'xls';
        fileType['xlsx'] = 'xls';
        fileType['txt'] = 'txt';
        fileType = fileType[type] || 'ppt';
        return 	fileType+suffix;
    }

})( jQuery );