import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { DetectedObjectService } from "./detectedObject.service";
import { DetectedObjectControllerBase } from "./base/detectedObject.controller.base";

@swagger.ApiTags("detectedObjects")
@common.Controller("detectedObjects")
export class DetectedObjectController extends DetectedObjectControllerBase {
  constructor(
    protected readonly service: DetectedObjectService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
