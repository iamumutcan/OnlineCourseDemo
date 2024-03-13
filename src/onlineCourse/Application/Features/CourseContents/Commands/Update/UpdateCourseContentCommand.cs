using Application.Features.CourseContents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseContents.Commands.Update;

public class UpdateCourseContentCommand : IRequest<UpdatedCourseContentResponse>
{
    public Guid Id { get; set; }
    public string Summary { get; set; }
    public Guid CourseId { get; set; }

    public class UpdateCourseContentCommandHandler : IRequestHandler<UpdateCourseContentCommand, UpdatedCourseContentResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseContentRepository _courseContentRepository;
        private readonly CourseContentBusinessRules _courseContentBusinessRules;

        public UpdateCourseContentCommandHandler(IMapper mapper, ICourseContentRepository courseContentRepository,
                                         CourseContentBusinessRules courseContentBusinessRules)
        {
            _mapper = mapper;
            _courseContentRepository = courseContentRepository;
            _courseContentBusinessRules = courseContentBusinessRules;
        }

        public async Task<UpdatedCourseContentResponse> Handle(UpdateCourseContentCommand request, CancellationToken cancellationToken)
        {
            CourseContent? courseContent = await _courseContentRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseContentBusinessRules.CourseContentShouldExistWhenSelected(courseContent);
            courseContent = _mapper.Map(request, courseContent);

            await _courseContentRepository.UpdateAsync(courseContent!);

            UpdatedCourseContentResponse response = _mapper.Map<UpdatedCourseContentResponse>(courseContent);
            return response;
        }
    }
}