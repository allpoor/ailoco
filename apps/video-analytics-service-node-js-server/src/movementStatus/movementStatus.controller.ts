import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { MovementStatusService } from "./movementStatus.service";
import { MovementStatusControllerBase } from "./base/movementStatus.controller.base";

@swagger.ApiTags("movementStatuses")
@common.Controller("movementStatuses")
export class MovementStatusController extends MovementStatusControllerBase {
  constructor(
    protected readonly service: MovementStatusService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
