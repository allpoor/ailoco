import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { VideoStreamService } from "./videoStream.service";
import { VideoStreamControllerBase } from "./base/videoStream.controller.base";

@swagger.ApiTags("videoStreams")
@common.Controller("videoStreams")
export class VideoStreamController extends VideoStreamControllerBase {
  constructor(
    protected readonly service: VideoStreamService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
