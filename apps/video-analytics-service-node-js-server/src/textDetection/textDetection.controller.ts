import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { TextDetectionService } from "./textDetection.service";
import { TextDetectionControllerBase } from "./base/textDetection.controller.base";

@swagger.ApiTags("textDetections")
@common.Controller("textDetections")
export class TextDetectionController extends TextDetectionControllerBase {
  constructor(
    protected readonly service: TextDetectionService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
