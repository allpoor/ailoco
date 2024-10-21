import * as graphql from "@nestjs/graphql";
import * as nestAccessControl from "nest-access-control";
import * as gqlACGuard from "../auth/gqlAC.guard";
import { GqlDefaultAuthGuard } from "../auth/gqlDefaultAuth.guard";
import * as common from "@nestjs/common";
import { VideoStreamResolverBase } from "./base/videoStream.resolver.base";
import { VideoStream } from "./base/VideoStream";
import { VideoStreamService } from "./videoStream.service";

@common.UseGuards(GqlDefaultAuthGuard, gqlACGuard.GqlACGuard)
@graphql.Resolver(() => VideoStream)
export class VideoStreamResolver extends VideoStreamResolverBase {
  constructor(
    protected readonly service: VideoStreamService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
