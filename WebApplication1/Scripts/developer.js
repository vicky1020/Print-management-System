//Developer Js 
//Author : J.Satham Ussain // satham.edu@gmail.com

$(document).ready(function(){  
     // var base_url='http://localhost/Master/OFFSET/';
     var base_url='http://webspaprojects.co.in/minioffset/';
	/*=================magesh===============*/
         
        /*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
	/*========================================
	      Site Customizer Complete Script
	 =========================================*/
	 $('.button-bg-changer').click(function(){
		 var style=$(this).attr('data-val');
		 $("body").css({
              "background": style
          });
		  $.ajax({
		   url:base_url+'dashboard/change_bg',
		   data:'style='+style,
		   type:'POST',
		   success:function(data){
			return true;
			}
		   });  
	  });
	
	/*===================================
	      Common Code
	=====================================*/
	$('.numbersOnly').keyup(function () { 
    this.value = this.value.replace(/[^0-9\.]/g,'');
    });
   
   $(document).on('keyup','.floting',function(){
	 this.value = this.value.replace(/[^0-9\.]/g,'');
	});
	
   $('.page_reloder').click(function(){
    location.reload();	   
	}); 
  
   $('#table_exporter').click(function(){
     $(".export_this").table2excel({
    // exclude CSS class
    exclude: ".noExl",
    name: "Worksheet Name",
    filename: "report" //do not include extension
     });  
	}); 
	
	$('.table_exporter_custom').click(function(){
     var date_table=$(this).attr('data-table');
	 $("."+date_table).table2excel({
    // exclude CSS class
    exclude: ".noExl",
    name: "Worksheet Name",
    filename: "report" //do not include extension
     });  
	}); 
  
	/*=================================
	   Size Measurement Callculation
	 ==================================*/
	 $('.size_size').blur(function(){
	  var size=$(this).val();
	  if (size.indexOf("x") >= 0){
		size=size.replace(/\s+/g, '');
		var temp = size.split("x");
		var messure=parseFloat(temp[0])*parseFloat(temp[1]);
	    $('.size_unit').val(messure);
	  }
	  else{ 
	  if (size.indexOf("X") >= 0){
		size=size.replace(/\s+/g, '');
		var temp = size.split("X");
		var messure=parseFloat(temp[0])*parseFloat(temp[1]);
		$('.size_unit').val(messure);
	  }
	  else{ 
	  $('.size_unit').val(' '); }
	  }
	  
	 });
	 
	 
	 /*===============================
	      Extre Work Hide & Show 
	 =================================*/
	
	$('.wtype_trigger').change(function(){
		var temp=$(this).val();
		if(temp==2){
		$('.add_div').removeClass('hide');	
		}
		else{
		$('.add_div').addClass('hide');	
		}
	}); 
	
	$(".price_calc_trigger").on("ifChanged",function(){
		if($('.price_calc_trigger').is(':checked'))
		{
		  $('.price_qty_div').addClass('hide');
                  $('*.add_place_holder').attr('placeholder','Please enter price per sq. Inch');	
		}
		else{
		  $('.price_qty_div').removeClass('hide');
                   $('*.add_place_holder').removeAttr('placeholder','Please enter price per sq. Inch');	
		}
	});
	
	/*======================================
	    All Script Used to create Job Card
	 =======================================*/
	 $('#jc_client').change(function(){
	 var job_type=$("#jc_job_type").val();	 
	 if(job_type==3){$("#jc_job_type").val('');}	 
	});
	 
	 $("#jc_job_type").change(function(){
	  
	  var temp_job_type=$(this).val();
	  $('*.rst_input').val('');
	  $('#jc_paper_source,#jc_paper_brand,#jc_paper_size,#jc_paper_type,#jc_paper_gsm,#jc_feeding_size').val(null).trigger("change");
	  if(temp_job_type==1){
		$.ajax({
		   url:base_url+'jobs/Ajax_Job_List',
		   data:'job_type='+temp_job_type,
		   type:'POST',
		   success:function(data){
			$('#jc_job').html(data);
			}
		   });  
	  }
	  else if(temp_job_type==2){
	    $('.paper_info_div').addClass('hide');
		$.ajax({
		   url:base_url+'jobs/Ajax_Sub_Size_List',
		   type:'POST',
		   success:function(data){
			$('#jc_feeding_size').html(data);
			}
		   });  	  
	  }
	  else if(temp_job_type==3){
	  var client_id=$('#jc_client').val();
	  $('.old_job_card_div').removeClass('hide');	
			if(client_id==''){
			$('#jc_job_card').html('<option value="">Select Job Card</option>');
			}
			else{
				$.ajax({
					url:base_url+'jobs/Ajax_Jobcard_List',
					data:'client_id='+client_id,
					type:'POST',
					success:function(data){
						$('#jc_job_card').html(data);
						$('#jc_job_card').select2({
						 placeholder: "Select Job Card",
						 width: '100%',
						 allowClear: true
						 }); 
						}
				});  
		    }
	   }
	 
	  if(temp_job_type!=3){
		$('.old_job_card_div').addClass('hide');  
	  }
	  if(temp_job_type!=2){
		$('.paper_info_div').removeClass('hide');  
	  }
	});
	
	$("#jc_job").change(function(){
	  var work_id=$(this).val();
		$.ajax({
		   url:base_url+'jobs/Ajax_Feeding_Size',
		   data:'work_id='+work_id,
		   type:'POST',
		   success:function(data){
			$('#jc_feeding_size').html(data);
			}
		   });  
	});
	
	/*=========================================
	      The Biggest Acction
	  ========================================*/
	 $('#jc_job_card').change(function(){
		var job_card=$(this).val();
		$('#jc_sub_job_count,#jc_custom_count').val(0);
		$('#sub_work_adder,#custom_field_adder').html('');
		$('*.rst_input').val('');
		if(job_card==''){
		$('*.rst_input').val('');	
		}else{
		   $.ajax({
		   url:base_url+'jobs/Ajax_Complete_Fetcher',
		   data:'job_card='+job_card,
		   type:'POST',
		   success:function(data){
			 var tmp=data.split('-@-');  
			$('#jc_job').html(tmp[0]);
			$('#jc_paper_source').html(tmp[1]);
			$('#jc_paper_brand').html(tmp[2]);
			$('#jc_paper_size').html(tmp[3]);
			$('#jc_paper_type').html(tmp[4]);
			$('#jc_paper_gsm').html(tmp[5]);
			$('#jc_paper_qty').val(tmp[6]);
			$('#jc_feeding_type').val(tmp[7]);
			$('#jc_finishing_size').val(tmp[8]);
			$('#jc_feeding_size').html(tmp[9]);
			$('#jc_feeding_qty').val(tmp[10]);
			$('#jc_waste_qty').val(tmp[11]);
			$('#jc_ups').val(tmp[12]);
			$('#jc_pieces').val(tmp[13]);
			$('#jc_notes').val(tmp[14]);
			$('#jc_sub_job_count').val(tmp[15]);
			$('#jc_custom_count').val(tmp[16]);
			$('#sub_work_adder').html(tmp[17]);
			$('#custom_field_adder').html(tmp[18]);
			}
		   });  
			
			
		} 
		 
	 });  	
	/*======================================
	    Paper Cost Callcualtion Script
	 =======================================*/
	$('#jc_paper_source').change(function(){
	$('#jc_paper_brand').val(null).trigger("change");
	});
	
	
	$('#jc_paper_brand').change(function(){
	 var job_type=$('#jc_job_type').val();
	 var paper_source=$('#jc_paper_source').val(); 
	 var paper_brand=$(this).val();
	 $.ajax({
		   url:base_url+'jobs/Ajax_Paper_Size',
		   data:'job_type='+job_type+'&paper_source='+paper_source+'&paper_brand='+paper_brand,
		   type:'POST',
		   success:function(data){
			$('#jc_paper_size').html(data);
			}
		   });  
	});
	
	$('#jc_paper_size').change(function(){
	 var job_type=$('#jc_job_type').val();
	 var paper_source=$('#jc_paper_source').val(); 
	 var paper_brand=$('#jc_paper_brand').val();
	 var paper_size=$(this).val();
	 
	 $.ajax({
		   url:base_url+'jobs/Ajax_Paper_Type',
		   data:'job_type='+job_type+'&paper_source='+paper_source+'&paper_brand='+paper_brand+'&paper_size='+paper_size,
		   type:'POST',
		   success:function(data){
			$('#jc_paper_type').html(data);
			}
		   });  
	});
	
	$('#jc_paper_type').change(function(){
	 var job_type=$('#jc_job_type').val();
	 var paper_source=$('#jc_paper_source').val(); 
	 var paper_brand=$('#jc_paper_brand').val();
	 var paper_size=$('#jc_paper_size').val();
	 var paper_type=$(this).val();
	 $.ajax({
		   url:base_url+'jobs/Ajax_Paper_Gsm',
		   data:'job_type='+job_type+'&paper_source='+paper_source+'&paper_brand='+paper_brand+'&paper_size='+paper_size+'&paper_type='+paper_type,
		   type:'POST',
		   success:function(data){
			$('#jc_paper_gsm').html(data);
			}
		   });  
	});
	
	/*=======================================
	    Feeding Qty & No of UPS callculation
	  =======================================*/
	  
	  $('#jc_feeding_size,#jc_paper_size').change(function(){
	   var paper_size=$('#jc_paper_size').val();
	   var paper_qty=$('#jc_paper_qty').val();
	   var feeding_size=$('#jc_feeding_size').val();
	  if(paper_size!='' && paper_qty!='' && feeding_size!=''){
	  $.ajax({
		   url:base_url+'jobs/Feeding_Qty_calc',
		   data:'paper_size='+paper_size+'&paper_qty='+paper_qty+'&feeding_size='+feeding_size,
		   type:'POST',
		   success:function(data){
			$('#jc_feeding_qty').val(data).removeClass('err_field');
			Upsqty();
			}
		   });
	  }
	  });
	  	
	  $('#jc_paper_qty').keyup(function(){
	   var paper_size=$('#jc_paper_size').val();
	   var paper_qty=$('#jc_paper_qty').val();
	   var feeding_size=$('#jc_feeding_size').val();
	   if(paper_size!='' && paper_qty!='' && feeding_size!=''){
	  $.ajax({
		   url:base_url+'jobs/Feeding_Qty_calc',
		   data:'paper_size='+paper_size+'&paper_qty='+paper_qty+'&feeding_size='+feeding_size,
		   type:'POST',
		   success:function(data){
			$('#jc_feeding_qty').val(data).removeClass('err_field');
			Upsqty();
			}
		   });
	   }
	  });
	
	/*=======================================
	       No of UPS & Pcs callculation
	  =======================================*/
	$('#jc_ups,#jc_feeding_qty').keyup(function(){
	 Upsqty();	
	});
	
	/*========================================
	    Add & Remove Extra Work
	  ========================================*/
	$('.jc_work_add_trigger').click(function(){
	$('.error_fetcher').html('');	 	
	 var last_id=$('#sub_work_adder div.form-group').last().attr('id');
	 var job_count=parseInt($('#jc_sub_job_count').val());
	 $('#jc_sub_job_count').val(job_count+1);
		if(typeof last_id === "undefined"){
		last_id=0;
		}else{
		last_id=last_id.substr(8);
		}
	  $.ajax({
		   url:base_url+'jobs/Ajax_Add_Sub_Job',
		   data:'last_no='+last_id,
		   type:'POST',
		   success:function(data){
			$('#sub_work_adder').append(data);
			 $('.jc_sub_change_trigger').select2({
     			placeholder: "Select Sub Job",
				width: '100%',
     			allowClear: true
     			}); 
			}
		   });	
	}); 
	
	$(document).on('click','.jc_work_delete',function(){
		var job_count=parseInt($('#jc_sub_job_count').val());
	    $('#jc_sub_job_count').val(job_count-1);
		$(this).parent().remove();
	}); 
	$(document).on('change','.jc_sub_change_trigger',function(){
		var x=$(this).parent().parent();
		var job_id=$(this).val();
		if(job_id!=''){
		 $.ajax({
		   url:base_url+'jobs/Ajax_Sub_sides',
		   data:'job_id='+job_id,
		   type:'POST',
		   success:function(data){
			x.find('.dummy').html(data);
			}
		   });		
		}
		else{
		x.find('.dummy').html('');
		}
	}); 
	
	$('.jc_custom_add_trigger').click(function(){
		$('.error_fetcher').html('');
	 var last_id=$('#custom_field_adder div.form-group').last().attr('id');
	 var job_count=parseInt($('#jc_custom_count').val());
	 $('#jc_custom_count').val(job_count+1);
		if(typeof last_id === "undefined"){
		last_id=0;
		}else{
		last_id=last_id.substr(8);
		}
	  $.ajax({
		   url:base_url+'jobs/Ajax_Add_Custom',
		   data:'last_no='+last_id,
		   type:'POST',
		   success:function(data){
			$('#custom_field_adder').append(data);
			}
		   });	
	}); 
	
	$(document).on('click','.jc_cst_delete',function(){
		var job_count=parseInt($('#jc_custom_count').val());
	    $('#jc_custom_count').val(job_count-1);
		$(this).parent().remove();
	}); 
	
	/*================================
	      Job Card From Validation
	  ================================*/
	  $('.jc_form_submit_spl').click(function(e){
		  var $this = $(this);
          $this.button('loading');
		  $('#jc_job_type').val();
		var x=0;
		e.preventDefault();
		$("#jc_form_spl input:not(.hide input):not(input.select2-search__field),#jc_form_spl select:not(.hide select)").each(function(){
		var data=$(this).val();
		if(data=='' || data==null){
		 x=1;
		 $(this).addClass("err_field");
		 $(this).parent().find('.select2-container').addClass("err_field");
		}
		else{
		$(this).removeClass("err_field");
		$(this).parent().find('.select2-container').removeClass("err_field");	
		}
		});
		if(x==0){
		 var job_type=$('#jc_job_type').val();
         var sub_count=parseInt($('#jc_sub_job_count').val());
		 var cst_count=parseInt($('#jc_custom_count').val());
		 var total_extra=sub_count+cst_count;
		 if(total_extra==0 && job_type==2){
			x=1; 
		 $('.error_fetcher').html('<div class="alert alert-danger col-xs-12 col-md-8 col-md-push-2"><button data-dismiss="alert" class="close" type="button">×</button><span class="entypo-attention"></span> Minimum One Sub Job or Custom Job Required.</div>');	 
		 }	
 		}
		if(x==0){ 
		var jc_type=$('#job_card_type').val();
		if(jc_type==1){
		$('#jc_form_spl').submit();
		}
		else{
		setTimeout(function() {
       $this.button('reset');
        }, 3000);
		$.ajax({
		   url:base_url+'jobs/Ajax_Estimation_Generater',
		   data:$("#jc_form_spl").serialize(),
		   type:'POST',
		   success:function(data){
			var test=data.split('----');
			$('.inv_date_diplayer').html(test[0]);
			$('.client_name_displayer').html(test[1]);
			$('.client_address_displayer').html(test[2]);
			$('.client_city_displayer').html(test[3]);   
			$('.job_card_content').html(test[4]);
			}
		   });		
		$('.estimation_trigger').trigger('click');
		}
		}
		else{
		setTimeout(function() {
       $this.button('reset');
        }, 3000);
		}
		
	 });	
	 
	 /*================================
	      DC & Invoice From Validation
	  ================================*/  
	 
	 $('.jc_form_submit').click(function(e){
		 var $this = $(this);
         $this.button('loading'); 
		var x=0;
		e.preventDefault();
		$("#jc_form input:not(.hide input):not(input.select2-search__field),#jc_form select:not(.hide select)").each(function(){
		var data=$(this).val();
		if(data=='' || data==null){
		 x=1;
		 $(this).addClass("err_field");
		 $(this).parent().find('.select2-container').addClass("err_field");
		}
		else{
		$(this).removeClass("err_field");
		$(this).parent().find('.select2-container').removeClass("err_field");	
		}
		});
		if(x==0){ $('#jc_form').submit();}
		else{
		setTimeout(function() {
       $this.button('reset');
        }, 3000);
		}
	 });	  
	 
	 $(document).on('keyup','input.err_field',function(){
		var data=$(this).val();
		if(data!=''){$(this).removeClass('err_field');}
	}); 
	$(document).on('change','select.err_field',function(){
		var data=$(this).val();
		if(data!=''){$(this).removeClass('err_field');
		$(this).parent().find('.select2-container').removeClass("err_field");	
		}
	}); 
	
	/*=================================================
	  Generate JOB Card and Print Job Card
	===================================================*/
	
	$('.jc_view_card').click(function(){
	    var jc_id=$(this).attr('data-id');
		 $.ajax({
		   url:base_url+'jobs/Ajax_Job_card_View',
		   data:'job_card_id='+jc_id,
		   type:'POST',
		   success:function(data){
			var test=data.split('----');
			$('.client_name_displayer').html(test[0]);
			$('.client_address_displayer').html(test[1]);
			$('.client_city_displayer').html(test[2]);   
			$('.job_card_content').html(test[3]);
			$('*#pdf_generate_trigger').attr('href',base_url+'jobs/job_card_pdf/'+jc_id);
			}
		   });	
	});
	
	$('.estimate_pop_trigger').click(function(){
	    var job_id=$(this).attr('data-id');
		 $.ajax({
		   url:base_url+'jobs/Ajax_Estimation_View',
		   data:'job_id='+job_id,
		   type:'POST',
		   success:function(data){
			var test=data.split('----');
			$('.inv_code_diplayer').html(test[0]);
			$('.inv_date_diplayer').html(test[1]);
			$('.client_name_displayer').html(test[2]);
			$('.client_address_displayer').html(test[3]);
			$('.client_city_displayer').html(test[4]);   
			$('.job_card_content').html(test[5]);
			$('#pdf_estimation_trigger').attr('href',base_url+'jobs/estiamtion_pdf/'+job_id);
			}
		   });	
	});
	
	/*===========================================
	        PDF Generation
	  ===========================================*/
	$('*#job_print_trigger').click(function(){
	window.print(); 
	});
	/*==========================================
	         Edit Job Card Price
	============================================*/	  
	$('.jc_price_edit_trigger').click(function(){
	    var jc_id=$(this).attr('data-id');
		 $.ajax({
		   url:base_url+'jobs/Ajax_Price_edit',
		   data:'job_card_id='+jc_id,
		   type:'POST',
		   success:function(data){
			$('.price_edit_content').html(data);
			}
		   });	
	});
	
	$(document).on('click','.price_update_trigger',function(){
	 var job_work_id=$(this).attr('data-id');
	 var x=$(this).parent();
	 var price=x.find('.price_edit_val').val();
	 price=parseFloat(price).toFixed(2);
	  $.ajax({
		   url:base_url+'jobs/Ajax_Price_update',
		   data:'job_work_id='+job_work_id+'&price='+price,
		   type:'POST',
		   success:function(data){
			$('.pay_edit_result').html(data);
			}
		   });	
		
	});
	
	
	/*===========================================
	         DC Genration and ALL Function
	 ============================================*/
	 $('#dc_client').change(function(){
		var client_id=$(this).val();
		if(client_id==''){$('#dc_job_card').html('<option value="">Select Job Card</option>'); return false;} 
		$.ajax({
		   url:base_url+'dc/Ajax_Get_Jobcard',
		   data:'client_id='+client_id,
		   type:'POST',
		   success:function(data){
			$('#dc_job_card').html(data);
			}
		   });	
	 });   
		  $('#dc_job_card').change(function(){
		 var job_card=$(this).val();
		if(job_card==''){$('#dc_qty').val(); return false;} 
		$.ajax({
		   url:base_url+'dc/Ajax_Get_Jobcard_bal',
		   data:'job_card='+job_card,
		   type:'POST',
		   success:function(data){
			$('#dc_qty').val(data);
			}
		   });
	 });
	 
	 $('.dc_view_trigger').click(function(){
	    var dc_id=$(this).attr('data-id');
		 $.ajax({
		   url:base_url+'dc/Ajax_Dc_View',
		   data:'dc_id='+dc_id,
		   type:'POST',
		   success:function(data){
			var test=data.split('----');
			$('.dc_code_diplayer').html(test[0]);
			$('.dc_date_diplayer').html(test[1]);
			$('.client_name_displayer').html(test[2]);
			$('.client_address_displayer').html(test[3]);
			$('.client_city_displayer').html(test[4]);   
			$('.job_card_content').html(test[5]);
			$('*#pdf_generate_trigger').attr('href',base_url+'dc/dc_pdf/'+dc_id);
			}
		   });	
	});
	
	/*===========================================
	         Invoice Genration and ALL Function
	 ============================================*/
	 $('#inv_client').change(function(){
		var client_id=$(this).val();
		if(client_id==''){$('#inv_job_card').html('<option value="">Select Job Card</option>'); $('.rst_input').val(''); return false;} 
		$.ajax({
		   url:base_url+'invoice/Ajax_Fetch_Jobcard',
		   data:'client_id='+client_id,
		   type:'POST',
		   success:function(data){
			var test=data.split('-@-');
			$('#inv_name').val(test[0]);
			$('#inv_address').val(test[1]);
			$('#inv_city').val(test[2]);
			$('#inv_tin').val(test[3]);   
			$('#inv_job_card').html(test[4]);
			}
		   });	
	 });   
	 
	 $('.inv_view_trigger').click(function(){
	    var inv_id=$(this).attr('data-id');
		 $.ajax({
		   url:base_url+'invoice/Ajax_Invoice_View',
		   data:'invoice_id='+inv_id,
		   type:'POST',
		   success:function(data){
			var test=data.split('----');
			$('.inv_code_diplayer').html(test[0]);
			$('.inv_date_diplayer').html(test[1]);
			$('.client_name_displayer').html(test[2]);
			$('.client_address_displayer').html(test[3]);
			$('.client_city_displayer').html(test[4]);   
			$('.job_card_content').html(test[5]);
			$('*#pdf_generate_trigger').attr('href',base_url+'invoice/invoice_pdf/'+inv_id);
			}
		   });	
	});
	
	$('.inv_payment_trigger').on("ifChanged",function(){
	 var type=$(this).val();
	 if(type==1){
	 $('.pay_info_div').removeClass('hide');	 
	 }
	 else
	 {
	 $('.pay_info_div').addClass('hide');	 
	 }
	});
	
	/*=============================================
	       All Payment Activities 
	===============================================*/
	$('#pay_client').change(function(){
		var client_id=$(this).val();
		$.ajax({
		   url:base_url+'payments/Ajax_Credit_Finder',
		   data:'client_id='+client_id,
		   type:'POST',
		   success:function(data){
			$('#pay_pending').val(parseFloat(data).toFixed(2));
			}
		   });	
		
	});
	
	$('.pay_view_trigger').click(function(){
	    var pay_id=$(this).attr('data-id');
		 $.ajax({
		   url:base_url+'payments/Ajax_Paymet_view',
		   data:'payment_id='+pay_id,
		   type:'POST',
		   success:function(data){
			var test=data.split('----');
			$('.pay_receiver_diplayer').html(test[0]);
			$('.pay_date_diplayer').html(test[1]);
			$('.client_name_displayer').html(test[2]);
			$('.client_address_displayer').html(test[3]);
			$('.client_city_displayer').html(test[4]);   
			$('.job_card_content').html(test[5]);
			$('*#pdf_generate_trigger').attr('href',base_url+'payments/payments_pdf/'+pay_id);
			}
		   });	
	});
	
	/*==============================================
          Artificial Inteligence Reporting System	
	================================================*/
	$('.report_closer').click(function(){
	   $(this).parent().parent().parent().parent().addClass('hide');	
	});
	
	$('.count_rotator').each(function () {
    $(this).prop('Counter',0).animate({
        Counter: $(this).text()
    }, {
        duration: 4000,
        easing: 'swing',
        step: function (now) {
            $(this).text(Math.ceil(now));
        }
    });
    });
	
	/*===========================================
	     Ledger Functionality
	  ===========================================*/
	 $('.ledger_filter').on("ifChanged",function(){
	  var filter=$(this).val();	 
	  if(filter==1){
		$('.date_ranger').addClass('hide');  
	  }
	  else{
		$('.date_ranger').removeClass('hide');  
	  }	 
	}); 
	/*=========================================
	     All Select Plugin Trigger COde
	  ==========================================*/
	$('#jc_client,#dc_client,#inv_client,#pay_client,#report_client').select2({
     placeholder: "Select Client Name",
	 width: '100%',
     allowClear: true
     }); 
	 
	 $('#jc_job').select2({
     placeholder: "Select Job",
	 width: '100%',
     allowClear: true
     }); 
	 
	 $('#jc_paper_source').select2({
     placeholder: "Select Paper Source",
	 width: '100%',
     allowClear: true
     }); 
	 
	 $('#jc_paper_brand').select2({
     placeholder: "Select Paper Brand",
	 width: '100%',
     allowClear: true
     }); 
	 
	 $('#jc_paper_size').select2({
     placeholder: "Select Paper Size",
	 width: '100%',
     allowClear: true
     }); 
	 
	 $('#jc_paper_type').select2({
     placeholder: "Select Paper Type",
	 width: '100%',
     allowClear: true
     }); 
	 
	 $('#jc_paper_gsm').select2({
     placeholder: "Select Paper GSM",
	 width: '100%',
     allowClear: true
     }); 
	 
	 $('#jc_feeding_size').select2({
     placeholder: "Select Finishing Size",
	 width: '100%',
     allowClear: true
     });
	 
	 $('#dc_job_card').select2({
     placeholder: "Select Job Card",
	 width: '100%',
     allowClear: true
     });
	 
	 $('#inv_job_card').select2({
     placeholder: "Select Job Card",
	 maximumSelectionLength: 3,
	 width: '100%',
     allowClear: true
     }); 
	 
});

 /*===============================
     Safe Triger Ups Calcualtion
  ================================*/
  
  function Upsqty(){
	var ups=$('#jc_ups').val();
	var feeding_qty=$('#jc_feeding_qty').val();
	var x=ups*feeding_qty;
	$('#jc_pieces').val(x).removeClass('err_field');  
  }	 
  

//TOGGLE CLOSE
    $('.nav-toggle').click(function() {
        //get collapse content selector
        var collapse_content_selector = $(this).attr('href');

        //make the collapse content to be shown or hide
        var toggle_switch = $(this);
        $(collapse_content_selector).slideToggle(function() {
            if ($(this).css('display') == 'block') {
                //change the button label to be 'Show'
                toggle_switch.html('<span class="entypo-minus-squared"></span>');
            } else {
                //change the button label to be 'Hide'
                toggle_switch.html('<span class="entypo-plus-squared"></span>');
            }
        });
    });


    $('.nav-toggle-alt').click(function() {
        //get collapse content selector
        var collapse_content_selector = $(this).attr('href');

        //make the collapse content to be shown or hide
        var toggle_switch = $(this);
        $(collapse_content_selector).slideToggle(function() {
            if ($(this).css('display') == 'block') {
                //change the button label to be 'Show'
                toggle_switch.html('<span class="entypo-up-open"></span>');
            } else {
                //change the button label to be 'Hide'
                toggle_switch.html('<span class="entypo-down-open"></span>');
            }
        });
        return false;
    });
    //CLOSE ELEMENT
    $(".gone").click(function() {
        var collapse_content_close = $(this).attr('href');
        $(collapse_content_close).hide();
    });

  