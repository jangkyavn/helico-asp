(window.webpackJsonp=window.webpackJsonp||[]).push([[16],{cO6r:function(n,e,t){"use strict";t.r(e),t.d(e,"RolesModule",(function(){return M}));var i=t("3Pt+"),a=t("HFJ6"),o=t("fXoL"),r=t("dEAy"),s=t("dihp"),c=t("QLLi"),l=t("ocnv"),u=t("B+r4"),d=t("PTRe"),b=t("OzZK"),p=t("RwU8"),g=t("C2AL"),h=t("FwiY");function z(n,e){if(1&n){const n=o.Zb();o.Yb(0,"div"),o.Yb(1,"button",8),o.gc("click",(function(){return o.yc(n),o.jc().destroyModal()})),o.Tb(2,"i",9),o.Gc(3,"H\u1ee7y "),o.Xb(),o.Yb(4,"button",10),o.gc("click",(function(){return o.yc(n),o.jc().saveChanges()})),o.Tb(5,"i",11),o.Gc(6,"L\u01b0u "),o.Xb(),o.Xb()}if(2&n){const n=o.jc();o.Cb(4),o.pc("nzLoading",n.loadingSaveChanges)}}let m=(()=>{class n{constructor(n,e,t,i){this.fb=n,this.modal=e,this.roleService=t,this.messageService=i,this.roles=[]}onKeyPress(n){n.ctrlKey&&"Enter"===n.key&&this.saveChanges()}ngOnInit(){this.createForm(),this.roleForm.reset(),this.roleForm.patchValue(Object.assign({},this.data))}createForm(){this.roleForm=this.fb.group({id:[null],name:[null,[i.p.required]],description:[null,[i.p.required]],position:[null],createdBy:[null],createdDate:[null],status:[null]})}saveChanges(){if(this.loadingSaveChanges=!0,this.roleForm.invalid){for(const n in this.roleForm.controls)this.roleForm.controls[n].markAsDirty(),this.roleForm.controls[n].updateValueAndValidity();return void(this.loadingSaveChanges=!1)}const n=this.roleForm.getRawValue();this.isAddNew?this.roleService.create(n).subscribe(n=>{n&&(this.messageService.success(a.a.CREATED_OK_MSG),this.loadingSaveChanges=!1,this.modal.destroy(!0)),this.loadingSaveChanges=!1},n=>{this.loadingSaveChanges=!1}):this.roleService.update(n).subscribe(n=>{n&&(this.messageService.success(a.a.UPDATED_OK_MSG),this.loadingSaveChanges=!1,this.modal.destroy(!0)),this.loadingSaveChanges=!1},n=>{this.loadingSaveChanges=!1})}destroyModal(){this.modal.destroy(!1)}}return n.\u0275fac=function(e){return new(e||n)(o.Sb(i.d),o.Sb(r.c),o.Sb(s.a),o.Sb(c.a))},n.\u0275cmp=o.Mb({type:n,selectors:[["app-role-add-edit-modal"]],hostBindings:function(n,e){1&n&&o.gc("keydown",(function(n){return e.onKeyPress(n)}),!1,o.xc)},inputs:{data:"data",isAddNew:"isAddNew"},decls:12,vars:9,consts:[["nz-form","","autocomplete","off",3,"formGroup"],["nzRequired","","nzFor","name",3,"nzSm","nzXs"],["nzErrorTip","Vui l\xf2ng nh\u1eadp t\xean.",3,"nzSm","nzXs"],["type","text","nz-input","","formControlName","name","id","name"],["nzRequired","","nzFor","description",3,"nzSm","nzXs"],["nzErrorTip","Vui l\xf2ng nh\u1eadp m\xf4 t\u1ea3.",3,"nzSm","nzXs"],["type","text","nz-input","","formControlName","description","id","description"],[4,"nzModalFooter"],["nz-button","","nzType","default",3,"click"],["nz-icon","","nzType","close","nzTheme","outline"],["nz-button","","nzType","primary",3,"nzLoading","click"],["nz-icon","","nzType","save","nzTheme","outline"]],template:function(n,e){1&n&&(o.Yb(0,"form",0),o.Yb(1,"nz-form-item"),o.Yb(2,"nz-form-label",1),o.Gc(3,"T\xean"),o.Xb(),o.Yb(4,"nz-form-control",2),o.Tb(5,"input",3),o.Xb(),o.Xb(),o.Yb(6,"nz-form-item"),o.Yb(7,"nz-form-label",4),o.Gc(8,"M\xf4 t\u1ea3"),o.Xb(),o.Yb(9,"nz-form-control",5),o.Tb(10,"input",6),o.Xb(),o.Xb(),o.Xb(),o.Ec(11,z,7,1,"div",7)),2&n&&(o.pc("formGroup",e.roleForm),o.Cb(2),o.pc("nzSm",7)("nzXs",24),o.Cb(2),o.pc("nzSm",17)("nzXs",24),o.Cb(3),o.pc("nzSm",7)("nzXs",24),o.Cb(2),o.pc("nzSm",17)("nzXs",24))},directives:[i.q,i.l,l.b,i.g,u.c,l.c,u.a,l.d,l.a,d.a,i.c,i.k,i.f,r.a,b.a,p.a,g.a,h.b],styles:[""]}),n})();var f=t("tyNb"),y=t("5+WD"),S=t("y6yg"),v=t("Nqz0"),D=t("rMZv"),P=t("ofXK"),C=t("Q8cG");function X(n,e){if(1&n){const n=o.Zb();o.Yb(0,"button",12),o.gc("click",(function(){o.yc(n);const e=o.jc(),t=o.wc(4);return e.search(t.value)})),o.Tb(1,"i",13),o.Xb()}}function T(n,e){if(1&n){const n=o.Zb();o.Yb(0,"tr",14),o.gc("contextmenu",(function(e){o.yc(n);const t=o.wc(6);return o.jc().contextMenu(e,t)}))("dblclick",(function(){o.yc(n);const t=e.$implicit;return o.jc().update(t)})),o.Yb(1,"td"),o.Gc(2),o.Xb(),o.Yb(3,"td"),o.Gc(4),o.Xb(),o.Yb(5,"nz-dropdown-menu",null,15),o.Yb(7,"ul",16),o.Yb(8,"li",17),o.gc("click",(function(){o.yc(n);const t=e.$implicit;return o.jc().update(t)})),o.Tb(9,"i",18),o.Gc(10,"Edit "),o.Xb(),o.Yb(11,"li",17),o.gc("click",(function(){o.yc(n);const t=e.$implicit;return o.jc().delete(t.id)})),o.Tb(12,"i",19),o.Gc(13,"Delete "),o.Xb(),o.Xb(),o.Xb(),o.Xb()}if(2&n){const n=e.$implicit;o.Cb(2),o.Hc(null==n?null:n.name),o.Cb(2),o.Hc(null==n?null:n.description)}}let k=(()=>{class n{constructor(n,e,t,i){this.modalService=n,this.nzContextMenuService=e,this.roleService=t,this.messageService=i,this.listOfData=[],this.loading=!0,this.pagination={},this.pagingParams={keyword:"",sortKey:"",sortValue:"",searchKey:"",searchValue:""}}ngOnInit(){this.loadData()}loadData(n=!1){n&&(this.pagination.currentPage=1),this.loading=!0,this.roleService.getAllPaging(this.pagination.currentPage||1,this.pagination.itemsPerPage||S.a.PAGE_SIZE,this.pagingParams).subscribe(n=>{this.loading=!1,this.pagination=n.pagination,this.listOfData=n.result,console.log(this.listOfData),0===this.listOfData.length&&1!==this.pagination.currentPage&&(this.pagination.currentPage-=1,this.loadData())})}create(){this.modalService.create({nzTitle:"Th\xeam m\u1edbi vai tr\xf2",nzContent:m,nzStyle:{top:S.a.MODAL_TOP},nzBodyStyle:{padding:S.a.MODAL_BODY_PADDING},nzMaskClosable:!1,nzClosable:!0,nzComponentParams:{data:{},isAddNew:!0}}).afterClose.subscribe(n=>{n&&this.loadData()})}update(n){this.roleService.getById(n.id).subscribe(n=>{this.modalService.create({nzTitle:"C\u1eadp nh\u1eadt vai tr\xf2",nzContent:m,nzStyle:{top:S.a.MODAL_TOP},nzBodyStyle:{padding:S.a.MODAL_BODY_PADDING},nzMaskClosable:!1,nzClosable:!0,nzComponentParams:{data:n,isAddNew:!1}}).afterClose.subscribe(n=>{n&&this.loadData()})})}delete(n){this.messageService.confirm(a.a.CONFIRM_DELETE_MSG,()=>{this.roleService.delete(n).subscribe(n=>{n&&(this.messageService.success(a.a.DELETED_OK_MSG),this.loadData())})},"danger")}onQueryParamsChange(n){const{pageSize:e,pageIndex:t,sort:i}=n,a=i.find(n=>null!==n.value);this.pagingParams.sortKey=a&&a.key||"",this.pagingParams.sortValue=a&&a.value||"",this.pagination.currentPage=t,this.pagination.itemsPerPage=e,console.log("a")}search(n){this.pagingParams.keyword=n,this.loadData(!0)}contextMenu(n,e){this.nzContextMenuService.create(n,e)}drop(n){Object(y.d)(this.listOfData,n.previousIndex,n.currentIndex),this.roleService.ChangePosition(this.listOfData).subscribe(n=>{n&&this.messageService.success(a.a.UPDATE_POSITION_OK)})}}return n.\u0275fac=function(e){return new(e||n)(o.Sb(r.d),o.Sb(v.a),o.Sb(s.a),o.Sb(c.a))},n.\u0275cmp=o.Mb({type:n,selectors:[["app-roles"]],decls:20,vars:9,consts:[["nz-row","",1,"table-actions"],["nz-col","","nzXs","24","nzSm","24","nzMd","12","nzLg","12","nzXl","12"],["nzSearch","",3,"nzAddOnAfter"],["type","text","nz-input","","placeholder","T\xecm ki\u1ebfm...",3,"keyup.enter"],["keyword",""],["suffixIconButton",""],["nz-col","","nzXs","24","nzSm","24","nzMd","12","nzLg","12","nzXl","12",1,"text-right"],["nz-button","","nzType","primary",3,"click"],["nz-icon","","nzType","plus","nzTheme","outline"],["nzShowSizeChanger","","nzBordered","","nzSize","small",3,"nzData","nzFrontPagination","nzShowQuickJumper","nzLoading","nzTotal","nzPageSize","nzPageIndex","nzQueryParams"],["cdkDropList","",1,"cursor-row",3,"cdkDropListDropped"],["cdkDrag","",3,"contextmenu","dblclick",4,"ngFor","ngForOf"],["nz-button","","nzType","primary","nzSearch","",3,"click"],["nz-icon","","nzType","search"],["cdkDrag","",3,"contextmenu","dblclick"],["menu","nzDropdownMenu"],["nz-menu",""],["nz-menu-item","",3,"click"],["nz-icon","","nzType","edit","nzTheme","outline"],["nz-icon","","nzType","delete","nzTheme","outline"]],template:function(n,e){if(1&n){const n=o.Zb();o.Yb(0,"div",0),o.Yb(1,"div",1),o.Yb(2,"nz-input-group",2),o.Yb(3,"input",3,4),o.gc("keyup.enter",(function(){o.yc(n);const t=o.wc(4);return e.search(t.value)})),o.Xb(),o.Xb(),o.Ec(5,X,2,0,"ng-template",null,5,o.Fc),o.Xb(),o.Yb(7,"div",6),o.Yb(8,"button",7),o.gc("click",(function(){return e.create()})),o.Tb(9,"i",8),o.Gc(10," Th\xeam m\u1edbi "),o.Xb(),o.Xb(),o.Xb(),o.Yb(11,"nz-table",9),o.gc("nzQueryParams",(function(n){return e.onQueryParamsChange(n)})),o.Yb(12,"thead"),o.Yb(13,"tr"),o.Yb(14,"th"),o.Gc(15,"Name"),o.Xb(),o.Yb(16,"th"),o.Gc(17,"Description"),o.Xb(),o.Xb(),o.Xb(),o.Yb(18,"tbody",10),o.gc("cdkDropListDropped",(function(n){return e.drop(n)})),o.Ec(19,T,14,2,"tr",11),o.Xb(),o.Xb()}if(2&n){const n=o.wc(6);o.Cb(2),o.pc("nzAddOnAfter",n),o.Cb(9),o.pc("nzData",e.listOfData)("nzFrontPagination",!1)("nzShowQuickJumper",(null==e.pagination?null:e.pagination.totalPages)>1)("nzLoading",e.loading)("nzTotal",null==e.pagination?null:e.pagination.totalItems)("nzPageSize",null==e.pagination?null:e.pagination.itemsPerPage)("nzPageIndex",null==e.pagination?null:e.pagination.currentPage),o.Cb(8),o.pc("ngForOf",e.listOfData)}},directives:[u.c,u.a,d.b,d.a,b.a,p.a,g.a,h.b,D.c,D.g,D.h,D.b,D.f,D.e,y.b,P.k,y.a,v.d,C.c,C.e],styles:[""]}),n})();const w=[{path:"",component:k,data:{breadcrumb:"Vai tr\xf2"}}];let O=(()=>{class n{}return n.components=[k],n.\u0275mod=o.Qb({type:n}),n.\u0275inj=o.Pb({factory:function(e){return new(e||n)},imports:[[f.i.forChild(w)],f.i]}),n})();var Y=t("UKGz");let M=(()=>{class n{}return n.\u0275mod=o.Qb({type:n}),n.\u0275inj=o.Pb({factory:function(e){return new(e||n)},imports:[[Y.a,O,y.c]]}),n})()}}]);