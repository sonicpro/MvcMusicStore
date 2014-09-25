/// <reference path="jquery-1.5.1.js" />
/// <reference path="jquery-ui-1.8.11.js" />

$(document).ready(function(){
						$('input[data-autocomplete-source]').each(function(){
																		var target = $(this);
																		target.autocomplete({ source: target.attr('data-autocomplete-source') });
																	}
																);

						$('#artistSearch').submit(function(event){
													// Do not post the form.
													event.preventDefault();
													var form = $(this);
													$.getJSON(form.attr('action'), form.serialize(), fillTemplate);
												}
											);
					}
				);

function fillTemplate(data){
	$('#artistTemplate').tmpl(data).appendTo('#artist-list');
}
