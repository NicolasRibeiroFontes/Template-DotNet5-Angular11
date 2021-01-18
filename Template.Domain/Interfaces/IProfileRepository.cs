using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IProfileRepository
	{
		Profile GetDefault();
	}
}
