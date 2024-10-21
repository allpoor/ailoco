import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { CameraService } from "./camera.service";
import { CameraControllerBase } from "./base/camera.controller.base";

@swagger.ApiTags("cameras")
@common.Controller("cameras")
export class CameraController extends CameraControllerBase {
  constructor(
    protected readonly service: CameraService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
