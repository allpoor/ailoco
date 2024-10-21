import * as graphql from "@nestjs/graphql";
import * as nestAccessControl from "nest-access-control";
import * as gqlACGuard from "../auth/gqlAC.guard";
import { GqlDefaultAuthGuard } from "../auth/gqlDefaultAuth.guard";
import * as common from "@nestjs/common";
import { DetectedObjectResolverBase } from "./base/detectedObject.resolver.base";
import { DetectedObject } from "./base/DetectedObject";
import { DetectedObjectService } from "./detectedObject.service";

@common.UseGuards(GqlDefaultAuthGuard, gqlACGuard.GqlACGuard)
@graphql.Resolver(() => DetectedObject)
export class DetectedObjectResolver extends DetectedObjectResolverBase {
  constructor(
    protected readonly service: DetectedObjectService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
