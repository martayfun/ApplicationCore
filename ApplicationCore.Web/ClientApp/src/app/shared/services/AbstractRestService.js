"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var AbstractRestService = /** @class */ (function () {
    function AbstractRestService(_http, actionUrl) {
        this._http = _http;
        this.actionUrl = actionUrl;
    }
    AbstractRestService.prototype.getAll = function () {
        return this._http.get(this.actionUrl);
    };
    AbstractRestService.prototype.getOne = function (id) {
        return this._http.get('${this.actionUrl}${id}');
    };
    return AbstractRestService;
}());
exports.AbstractRestService = AbstractRestService;
//# sourceMappingURL=AbstractRestService.js.map