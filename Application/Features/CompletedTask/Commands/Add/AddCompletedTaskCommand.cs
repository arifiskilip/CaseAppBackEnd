using Application.Repositories;
using Application.Services;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features
{
	public class AddCompletedTaskCommand : IRequest<AddCompletedTaskResponse>, ITransactionalRequest
	{
		public int TaskId { get; set; }
		public int Quantity { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }


		public class AddCompletedTaskCommandHandler : IRequestHandler<AddCompletedTaskCommand, AddCompletedTaskResponse>
		{
			private readonly ICompletedTaskRepository _completedTaskRepository;
			private readonly IMapper _mapper;
			private readonly CompletedTaskBusinessRules _businessRules;
			private readonly ITaskService _taskService;
			public AddCompletedTaskCommandHandler(ICompletedTaskRepository completedTaskRepository, IMapper mapper, ITaskService taskService, CompletedTaskBusinessRules businessRules)
			{
				_completedTaskRepository = completedTaskRepository;
				_mapper = mapper;
				_taskService = taskService;
				_businessRules = businessRules;
			}

			public async Task<AddCompletedTaskResponse> Handle(AddCompletedTaskCommand request, CancellationToken cancellationToken)
			{
				var task = await _taskService.GetByIdAsync(request.TaskId);
				await _businessRules.CheckTargetNumberAsync(task:task, quantity:request.Quantity);
				CompletedTask completedTask = _mapper.Map<CompletedTask>(request);
				completedTask.UserId = 1;
				await _completedTaskRepository.AddAsync(entity: completedTask);
				task.Performed += request.Quantity;
				await _taskService.UpdateAsync(task:task);
				return new()
				{
					Message = GeneralMessages.SuccessAdded
				};
			}
		}
	}
}
