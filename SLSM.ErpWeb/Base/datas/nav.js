var navs = [
    {
        title: "设计师管理",
        icon: "&#xe613;",
        spread: false,
        href: "../../Designer/DesignerInfo",
        value: "DesignerInfo"

    },
    {
        "title": "生产管理",
        "icon": "&#xe613;",
        "spread": false,
        "href": "../../Designer/ManufactureInfo?OrderText=1",
        "value": "ManufactureInfo"
    },
    {
        "title": "客服管理",
        "icon": "fa-shopping-cart",
        "spread": false,
        "children": [
            {
                "title": "订单管理",
                "icon": "&#xe60a;",
                "href": "../../Service/OrderInfo?ReturnText=1",
                "value": "OrderInfo"
            }

        ]
    }, {
        "title": "产品档案管理",
        "icon": "fa-list",
        "spread": false,
        "children": [
            {
                "title": "产品档案管理",
                "icon": "&#xe60a;",
                "href": "../../Material/MaterialManger",
                "value": "MaterialManger"
            },
            {
                "title": "供应商管理",
                "icon": "fa-gift",
                "href": "../../Material/ProducerInfo",
                "value": "ProducerInfo"
            },
            {
                "title": "待采购列表",
                "icon": "&#xe60a;",
                "href": "../../Material/WaitBuyerInfo",
                "value": "WaitBuyerInfo"
            },
            {
                "title": "采购单管理",
                "icon": "&#xe620;",
                "href": "../../Material/BuyerInfo?PrintText=1",
                "value": "BuyerInfo"
            },
            {
                "title": "供应商管理",
                "icon": "fa-gift",
                "href": "../../Material/ProducerInfo",
                "value": "ProducerInfo"
            },

        ]
    }, {
        "title": "品检管理",
        "icon": "fa-comments",
        "spread": false,
        "children": [
            {
                "title": "原材料品检",
                "icon": "&#xe612;",
                "href": "../../Inspection/Raw_InspectionInfo",
                "value": "Raw_InspectionInfo"
            },
            {
                "title": "成品品检",
                "icon": "fa-comment",
                "href": '../../Inspection/Product_InspectionInfo?Text=1',
                "value": "Product_InspectionInfo"
            }
        ]
    }, {
        "title": "仓库管理",
        "icon": "fa-comments-o",
        "spread": false,
        "children": [
            {
                "title": "库存管理",
                "icon": "fa-comment-o",
                "href": "../../Warehouses/StorageInfo",
                "value": "StorageInfo"
            }, {
                "title": "采购入库",
                "icon": "fa-comment-o",
                "href": "../../Warehouses/BuyerInfo",
                "value": "BuyerInfo"
            }, {
                "title": "生产领料",
                "icon": "fa-comment-o",
                "href": "../../Warehouses/ReceiveInfo",
                "value": "ReceiveInfo"
            }, {
                "title": "仓库分类",
                "icon": "fa-comment-o",
                "href": "../../Warehouses/WarehouseInfo",
                "value": "WarehouseInfo"
            },
        ]
    }, {
        "title": "财务管理",
        "icon": " fa-comments",
        "spread": false,
        "children": [
            {
                "title": "应付账款",
                "icon": "fa-comment",
                "href": "../../Finance/WantFinance",
                "value": "WantFinance"
            },
            {
                "title": "发票记录",
                "icon": "fa-comment",
                "href": "../../Finance/InvoiceInfo",
                "value": "InvoiceInfo"
            }
        ]
    }, {
        "title": "发货管理",
        "icon": "fa-calculator",
        "spread": false,
        "href": '../../Consignment/ConsignmentInfo?Consignment=1',
        "value": "ConsignmentInfo"
    },
    {
        "title": "工艺设备管理",
        "icon": "fa-calculator",
        "spread": false,
        "children": [
            {
                "title": "定制工艺管理",
                "icon": "&#xe60a;",
                "href": "../../Equipment/TechnologyInfo",
                "value": "TechnologyInfo"
            },
            {
                "title": "颜色管理",
                "icon": "&#xe60a;",
                "href": "../../Equipment/ColorInfo",
                "value": "ColorInfo"
            }
        ]
    },
    {
        "title": "帐号权限设置",
        "icon": "fa-users",
        "spread": false,
        "children": [
            {
                "title": "管理平台帐号权限",
                "icon": "fa-user",
                "href": "../../Jurisdiction/JurisdictionInfo",
                "value": "JurisdictionInfo"
            }, {
                "title": "用户登录管理",
                "icon": "fa-user",
                "href": "../../Jurisdiction/ErpLoginUser",
                "value": "ErpLoginUser"
            }
        ]
    }
];