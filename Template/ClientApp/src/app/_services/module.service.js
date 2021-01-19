"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ModuleService = void 0;
var ModuleService = /** @class */ (function () {
    function ModuleService(http) {
        this.http = http;
        this._module = "api/modules";
    }
    ModuleService.prototype.getModules = function () {
        return this.http.get("/" + this._module);
    };
    return ModuleService;
}());
exports.ModuleService = ModuleService;
//# sourceMappingURL=module.service.js.map