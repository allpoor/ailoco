import * as graphql from "@nestjs/graphql";
import * as nestAccessControl from "nest-access-control";
import * as gqlACGuard from "../auth/gqlAC.guard";
import { GqlDefaultAuthGuard } from "../auth/gqlDefaultAuth.guard";
import * as common from "@nestjs/common";
import { TextDetectionResolverBase } from "./base/textDetection.resolver.base";
import { TextDetection } from "./base/TextDetection";
import { TextDetectionService } from "./textDetection.service";

@common.UseGuards(GqlDefaultAuthGuard, gqlACGuard.GqlACGuard)
@graphql.Resolver(() => TextDetection)
export class TextDetectionResolver extends TextDetectionResolverBase {
  constructor(
    protected readonly service: TextDetectionService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
